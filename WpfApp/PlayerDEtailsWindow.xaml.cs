using DataHandler;
using DataHandler.Models;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for PlayerDetailsWindow.xaml
    /// </summary>
    public partial class PlayerDetailsWindow : Window
    {
        private List<Match> _matches;
        private Player _player;
        private int yellowCards;
        private int goals;
        private TeamsResults selectedHome;
        private TeamsResults selectedGuest;
        private DataService dataService = new DataService();

        public PlayerDetailsWindow(Player player, List<Match> matches, TeamsResults selectedHome, TeamsResults selectedGuest)
        {
            InitializeComponent();
            DataContext = player;

            _player = player;
            _matches = matches;
            this.selectedHome = selectedHome;
            this.selectedGuest = selectedGuest;

            Loaded += Window_Loaded;

            var imagePaths = dataService.LoadImagePathsForWpf();
            string playerImagePath;
            if (imagePaths.ContainsKey(player.Name))
            {
                playerImagePath = imagePaths[player.Name];

            }
            else
            {
                playerImagePath = null;
            }

            string? imagePath = playerImagePath != null
                ? playerImagePath
                : System.IO.Path.GetFullPath("Assets/defaultpicture.jpg");

            this.image.Background = new ImageBrush(
                new BitmapImage(new Uri(imagePath))
            );

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_matches?.Count > 0)
            {
                foreach (var match in _matches)
                {
                    if (match.HomeTeamCountry == selectedHome.Country && match.AwayTeamCountry == selectedGuest.Country)
                    {
                        List<TeamEvent> allEvents = new List<TeamEvent>();
                        if (match.HomeTeamEvents != null)
                            allEvents.AddRange(match.HomeTeamEvents);
                        if (match.AwayTeamEvents != null)
                            allEvents.AddRange(match.AwayTeamEvents);

                        foreach (var ev in allEvents)
                        {
                            if (ev.Player == _player.Name)
                            {
                                if (ev.TypeOfEvent == DataHandler.Enums.TypeOfEvent.Goal)
                                {
                                    goals++;
                                }
                                else if (ev.TypeOfEvent == DataHandler.Enums.TypeOfEvent.YellowCard)
                                {
                                    yellowCards++;
                                }
                            }
                        }
                    }
                }
                lbYellowCards.Content = yellowCards;
                lbGoals.Content = goals;
            }
            else
            {
                lbYellowCards.Content = "0";
                lbGoals.Content = "0";
            }
        }

    }
}
