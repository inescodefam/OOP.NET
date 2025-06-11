using DataHandler;
using DataHandler.Converters;
using DataHandler.Models;
using Newtonsoft.Json;
using OOP.NET_project_KamberInes;
using RestSharp;
using System.Windows;
using System.Windows.Controls;
using WpfApp.Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<TeamsResults> _allTeams = new List<TeamsResults>();
        private List<Match> _allMatches = new List<Match>();
        private TeamsResults _selectedHome;
        private TeamsResults _selectedGuest;

        private UserSettings previousUserSettings = null;

        private bool isFemaleSelected = false;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            btnLandingContinue.IsEnabled = false;

            rbSize800px.Checked += rbResolution_Checked;
            rbSize1024px.Checked += rbResolution_Checked;
            rbSize845px.Checked += rbResolution_Checked;
            rbSize640px.Checked += rbResolution_Checked;
            rbSizeFullscreen.Checked += rbResolution_Checked;

            //if (ScreenSizeService.CurrentScreenSizeOption =! )
            //{
            //    ScreenSizeService.SetScreenSize(ScreenSizeService.CurrentScreenSizeOption, this);
            //}

        }

        private void rbResolution_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioChecked)
            {
                if (radioChecked == rbSize800px)
                {
                    ScreenSizeService.SetScreenSize(0, this);
                }
                else if (radioChecked == rbSize1024px)
                {
                    ScreenSizeService.SetScreenSize(1, this);
                }
                else if (radioChecked == rbSize845px)
                {
                    ScreenSizeService.SetScreenSize(2, this);
                }
                else if (radioChecked == rbSize640px)
                {
                    ScreenSizeService.SetScreenSize(3, this);
                }
                else if (radioChecked == rbSizeFullscreen)
                {
                    ScreenSizeService.SetScreenSize(4, this);
                }
            }
        }


        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await LoadRepresentation();

                previousUserSettings = UserSettings.SetFromUserSettings();

                if (previousUserSettings != null)
                {
                    if (previousUserSettings.Language == "hr")
                    {
                        rbCro.IsChecked = true;
                        App.TranslationInstance.ChangeLanguage("hr", this);
                    }
                    else
                    {
                        rbEng.IsChecked = true;
                        App.TranslationInstance.ChangeLanguage("en", this);
                    }

                    if (previousUserSettings.Gender)
                    {
                        rbFemale.IsChecked = true;
                        isFemaleSelected = true;
                    }
                    else
                    {
                        rbMale.IsChecked = true;
                        isFemaleSelected = false;
                    }

                    var selectedRepresentation = previousUserSettings.Representation;
                    cbRepresentation.SelectedItem = _allTeams.FirstOrDefault(d => d.ToString() == selectedRepresentation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured while trying to fetch teamResults from web server.", ex.Message);
            }
        }

        private async Task LoadRepresentation()
        {
            try
            {
                _allTeams = await GetData();
                _allMatches = await GetMatchesAsync();

                if (_allTeams == null || _allTeams.Count == 0 || _allMatches == null)
                {
                    MessageBox.Show("A critical error ocurred. No data received from the API. Application will now close.");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("A critical error ocurred. No teamResults received from the API. Application will now close.");
                return;
            }

            cbRepresentation.ItemsSource = _allTeams;
            cbRepresentation.DisplayMemberPath = null;
            if (cbRepresentation.Items.Count > 0)
            {
                btnLandingContinue.IsEnabled = true;
            }
        }

        private async Task<List<TeamsResults>> GetData()
        {
            try
            {
                RestClient client = isFemaleSelected
                    ? new RestClient(TeamsResults.TEAMS_RESULTS_F)
                    : new RestClient(TeamsResults.TEAMS_RESULTS_M);

                var response = await client.ExecuteAsync(new RestRequest());

                if (!response.IsSuccessful)
                {
                    MessageBox.Show($"API Error: {response.StatusCode} - {response.ErrorMessage}\nResponse: {response.Content}");
                    return null;
                }

                return JsonConvert.DeserializeObject<List<TeamsResults>>(response.Content, Converter.Settings);
            }
            catch
            {
                MessageBox.Show("API Error");
                return null;
            }
        }

        private void rbCro_Checked(object sender, RoutedEventArgs e)
        {
            App.TranslationInstance.ChangeLanguage("hr", this);
        }

        private void rbEng_Checked(object sender, RoutedEventArgs e)
        {
            App.TranslationInstance.ChangeLanguage("en", this);
        }

        private void DisplayMatchResults(List<Match> matches)
        {
            if (rbCro.IsChecked == true)
            {
                lbRepHost.Content = $"Domaćini: {_selectedHome.Country} " +
                   $"(W: {_selectedHome.Wins} D: {_selectedHome.Draws} L: {_selectedHome.Losses})";

                lbRepresentationGuest.Content = $"Gosti: {_selectedGuest.Country} " +
                $"(W: {_selectedGuest.Wins} D: {_selectedGuest.Draws} L: {_selectedGuest.Losses})";
            }
            else
            {
                lbRepHost.Content = $"Host: {_selectedHome.Country} " +
                    $"(W: {_selectedHome.Wins} D: {_selectedHome.Draws} L: {_selectedHome.Losses})";

                lbRepresentationGuest.Content = $"Guest: {_selectedGuest.Country} " +
                $"(W: {_selectedGuest.Wins} D: {_selectedGuest.Draws} L: {_selectedGuest.Losses})";

            }

        }

        private async void btnContinue_ClickAsync(object sender, RoutedEventArgs e)
        {
            if (_selectedHome == null || _selectedGuest == null)
            {
                MessageBox.Show("Please select both representations");
                return;
            }

            UserSettings u = new UserSettings();
            u.Language = rbCro.IsChecked == true ? "hr" : "en";
            u.Gender = rbFemale.IsChecked == true;
            u.Representation = cbRepresentation.SelectedItem?.ToString() ?? string.Empty;
            previousUserSettings.SaveSettings(u);

            var homeStats = await DataService.GetTeamStatistics(_selectedHome.FifaCode, isFemaleSelected, _selectedHome.Country);
            var guestStats = await DataService.GetTeamStatistics(_selectedGuest.FifaCode, isFemaleSelected, _selectedGuest.Country);

            var nextWindow = new MatchDetailsWindow(_selectedHome, _selectedGuest, homeStats, guestStats);
            nextWindow.Show();
            this.Close();
        }

        private void OnRepresentationChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbRepresentation.SelectedItem is TeamsResults selectedTeam)
            {
                _selectedHome = selectedTeam;
                _selectedGuest = _allTeams.FirstOrDefault(t => t != _selectedHome);
                if (_selectedGuest != null)
                {
                    DisplayMatchResults(new List<Match>());
                }
            }
            else
            {
                _selectedHome = null;
                _selectedGuest = null;
                lbRepHost.Content = "Host: ";
                lbRepresentationGuest.Content = "Guest: ";
            }
        }

        public void OnHomeRepresentationChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbRepresentation.SelectedItem is TeamsResults selectedHome)
            {
                _selectedHome = selectedHome;

                var opponentCountries = _allMatches
                .Where(m => m.HomeTeamCountry == _selectedHome.Country)
                .Select(m => m.AwayTeamCountry)
                .Distinct()
                .ToList();

                var availableGuests = _allTeams
                    .Where(t => opponentCountries.Contains(t.Country) && t != _selectedHome)
                    .ToList();


                cbRepresentationGuest.ItemsSource = availableGuests;
                cbRepresentationGuest.DisplayMemberPath = null;
                cbRepresentationGuest.SelectedItem = null;
                cbRepresentationGuest.IsEnabled = availableGuests.Count > 0;
            }
        }

        private async Task<List<Match>> GetMatchesAsync()
        {
            try
            {
                RestClient client = isFemaleSelected
                    ? new RestClient(Match.MATCH_F)
                    : new RestClient(Match.MATCH_M);

                var response = await client.ExecuteAsync(new RestRequest());

                if (!response.IsSuccessful)
                {
                    MessageBox.Show($"Failed to fetch matches: {response.StatusCode}");
                    return null;
                }

                return JsonConvert.DeserializeObject<List<Match>>(response.Content, Converter.Settings);
            }
            catch
            {
                MessageBox.Show("Error fetching matches");
                return null;
            }
        }

        private void rbFemale_Checked(object sender, RoutedEventArgs e)
        {
            this.isFemaleSelected = true;
            LoadRepresentation();
        }

        private void rbMale_Checked(object sender, RoutedEventArgs e)
        {
            this.isFemaleSelected = false;
            LoadRepresentation();
        }

    }
}