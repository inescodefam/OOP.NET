using DataHandler.Converters;
using DataHandler.Models;
using Newtonsoft.Json;
using RestSharp;

namespace OOP.NET_project_KamberInes
{
    public partial class LandingForm : Form
    {
        private const string SURE_TO_EXIT_TEXT = "Are you sure you want to exit?";
        private Translation translation = new();
        private bool isFemaleSelected = false;

        private List<TeamsResults> teamResults = new List<TeamsResults>();
        UserSettings previousUserSettings = null;

        public LandingForm()
        {

            InitializeComponent();
            translation.ApplyTranslations(this);
            btnLandingContinue.Enabled = false;
        }

        private void btnLandingContinue_Click(object sender, EventArgs e)
        {
            if (cbRepresentation.SelectedItem == null) return;

            string selectedRepresentation = cbRepresentation.SelectedItem.ToString();
            var selectedItem = teamResults.FirstOrDefault(d => d.ToString() == cbRepresentation.SelectedItem.ToString());

            UserSettings userSettings = new UserSettings
            {
                Language = rbCro.Checked ? "hr" : "en",
                Gender = isFemaleSelected,
                Representation = selectedRepresentation,
                CountryCode = selectedRepresentation.Split(" (")[1].Trim(')'),
            };
            DashboardForm dashbordForm = new DashboardForm(userSettings);
            translation.ApplyTranslations(dashbordForm);

            if (MessageBox.Show($"Do you want to save settings:\nChampionship =  {(userSettings.Gender ? "Women" : "Men")}\nRepresentation = {userSettings.Representation}\nLanguage ={(userSettings.Language == "hr" ? "Croatian" : "English")}", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                userSettings.SaveSettings(userSettings);

            this.Hide();
            dashbordForm.ShowDialog();
            //this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void btnLandingClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(SURE_TO_EXIT_TEXT, "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            ActiveForm?.Close();
        }

        private void rbCro_CheckedChanged(object sender, EventArgs e)
        {
            translation.ChangeLanguage("hr", this);
        }

        private void rbEng_CheckedChanged(object sender, EventArgs e)
        {
            translation.ChangeLanguage("en", this);
        }


        private async Task LoadRepresentation()
        {
            try
            {
                teamResults = await GetData();
                if (teamResults == null || teamResults.Count == 0)
                {
                    MessageBox.Show("A critical error ocurred. No teamResults received from the API. Application will now close.");
                    Application.Exit();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("A critical error ocurred. No teamResults received from the API. Application will now close.");
                Application.Exit();
                return;
            }

            cbRepresentation.DataSource = teamResults;
            cbRepresentation.DisplayMember = teamResults.ToString();
            if (cbRepresentation.Items.Count > 0)
            {
                btnLandingContinue.Enabled = true;
            }
        }

        private Task<List<TeamsResults>?> GetData()
        {
            try
            {
                return Task.Run(async () =>
                    {
                        RestClient client = new RestClient();
                        if (isFemaleSelected)
                        {
                            client = new RestClient(TeamsResults.TEAMS_RESULTS_F);
                        }
                        else
                        {
                            client = new RestClient(TeamsResults.TEAMS_RESULTS_M);
                        }

                        var response = await client.ExecuteAsync(new RestRequest());

                        if (!response.IsSuccessful)
                        {
                            MessageBox.Show($"API Error: {response.StatusCode} - {response.ErrorMessage}\nResponse: {response.Content}");

                            return null;
                        }

                        return JsonConvert.DeserializeObject<List<TeamsResults>>(response.Content, Converter.Settings);
                    });
            }
            catch
            {
                MessageBox.Show($"API Error");
                return null;
            }
        }


        private void rbFemale_CheckedChanged(object sender, EventArgs e) => isFemaleSelected = true;

        private void rbMale_CheckedChanged(object sender, EventArgs e) => isFemaleSelected = false;

        private async void LandingForm_Load(object sender, EventArgs e)
        {

            try
            {
                await LoadRepresentation();
                previousUserSettings = UserSettings.SetFromUserSettings();

                if (previousUserSettings != null)
                {

                    if (previousUserSettings.Language == "hr")
                    {
                        rbCro.Checked = true;
                    }
                    else
                    {
                        rbEng.Checked = true;
                    }
                    if (previousUserSettings.Gender)
                    {
                        rbFemale.Checked = true;
                        isFemaleSelected = true;
                    }
                    else
                    {
                        rbMale.Checked = true;
                        isFemaleSelected = false;
                    }

                    var selectedRepresentation = previousUserSettings.Representation;
                    cbRepresentation.SelectedItem = teamResults.FirstOrDefault(d => d.ToString() == selectedRepresentation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured while trying to fetch teamResults from web server.", ex.Message);
            }

        }
    }
}

