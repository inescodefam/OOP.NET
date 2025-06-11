using DataHandler.Enums;
using DataHandler.Models;
using OOP.NET_project_KamberInes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfApp.Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MatchDetailsWindow.xaml
    /// </summary>
    public partial class MatchDetailsWindow : Window
    {
        UserSettings userSettings = new UserSettings();
        private TeamsResults selectedHome;
        private TeamsResults selectedGuest;
        private Task<TeamStatistics> homeStats;
        private Task<TeamStatistics> guestStats;

        public MatchDetailsWindow(DataHandler.Models.TeamsResults selectedHome, DataHandler.Models.TeamsResults selectedGuest, TeamStatistics homeStats, TeamStatistics guestStats)
        {
            InitializeComponent();
            gridMainContianer.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.GetFullPath(@"FieldPlan.png"))));
            ScreenSizeService.SetScreenSize(ScreenSizeService.CurrentScreenSizeOption, this);

            lbName.Content = selectedHome.Country;
            lbFifaCode.Content = selectedHome.FifaCode;
            lbMatches.Content = selectedHome.GamesPlayed;
            lbWins.Content = selectedHome.Wins;
            lbLosses.Content = selectedHome.Losses;
            lbUndecided.Content = selectedHome.Draws;
            lbGoalsScored.Content = selectedHome.GoalsFor;
            lbGoalsTaken.Content = selectedHome.GoalsAgainst;
            lbDiff.Content = Math.Abs(selectedHome.GoalsAgainst - selectedHome.GoalsFor);

            LoadPlayers(homeStats, guestStats);
        }

        public MatchDetailsWindow(TeamsResults selectedHome, TeamsResults selectedGuest, Task<TeamStatistics> homeStats, Task<TeamStatistics> guestStats)
        {
            this.selectedHome = selectedHome;
            this.selectedGuest = selectedGuest;
            this.homeStats = homeStats;
            this.guestStats = guestStats;
        }

        private void btSettings_Click(object sender, RoutedEventArgs e)
        {
            var nextWindow = new MainWindow();
            nextWindow.Show();
            this.Close();
        }

        private void LoadPlayers(TeamStatistics homeTeam, TeamStatistics guestTeam)
        {
            AddPlayersToContainer(homeTeam.StartingEleven, gridHome);
            AddPlayersToContainer(guestTeam.StartingEleven, gridGuest);
        }

        private void AddPlayersToContainer(List<Player> players, Grid container)
        {
            foreach (var player in players)
            {
                var positionPanel = GetPositionPanel(player.Position, container);
                if (positionPanel == null) continue;

                var playerControl = new PlayerControl(player);
                playerControl.PlayerClicked += ShowPlayerDetails;
                positionPanel.Children.Add(playerControl);
            }
        }

        private StackPanel GetPositionPanel(Position position, Grid container)
        {
            return position switch
            {
                Position.Goalie => container.FindName("spHomeGoalie") as StackPanel,
                Position.Defender => container.FindName("spHomeDefender") as StackPanel,
                Position.Midfield => container.FindName("spHomeMidfield") as StackPanel,
                Position.Forward => container.FindName("spHomeForward") as StackPanel
            };
        }

        private void ShowPlayerDetails(Player player)
        {
            var detailsWindow = new PlayerDetailsWindow(player);
            detailsWindow.Owner = this;
            detailsWindow.ShowDialog();
        }

    }
}
