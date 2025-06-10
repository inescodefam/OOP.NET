using DataHandler;
using DataHandler.Enums;
using DataHandler.Models;

namespace OOP.NET_project_KamberInes
{
    public partial class DashboardForm : Form
    {
        private Translation translation = new();
        UserSettings userSettings = new UserSettings();
        private List<Player> players = new();
        private List<Player> favorites = new();
        private DataService dataService = new DataService();

        public DashboardForm(UserSettings userSettings)
        {
            InitializeComponent();
            this.userSettings = userSettings;
            translation.ApplyTranslations(this);
            lbSelectedRepresentationValue.Text = userSettings.Representation;

            flFavoritesPanel.AllowDrop = true;
            flFavoritesPanel.DragEnter += pnlFavorites_DragEnter;
            flFavoritesPanel.DragDrop += pnlFavorites_DragDrop;

            flPanelPayers.AllowDrop = true;
            flPanelPayers.DragEnter += pnlPanelPlayers_DragEnter;
            flPanelPayers.DragDrop += pnlPanelPlayers_DragDrop;
            translation.ApplyTranslations(toolStrip);

        }

        private void pnlFavorites_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PlayerCard)) && flFavoritesPanel.Controls.Count < 3)
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void pnlFavorites_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PlayerCard)) && flFavoritesPanel.Controls.Count < 3)
            {
                PlayerCard card = (PlayerCard)e.Data.GetData(typeof(PlayerCard));
                flPanelPayers.Controls.Remove(card);
                card.playerData.IsFavorite = true;
                flFavoritesPanel.Controls.Add(card);
                card.UpdateFavoriteIcon();

            }
            else
            {
                MessageBox.Show("You can only have up to 3 favorite players.");
            }
        }


        private void pnlPanelPlayers_DragEnter(object? sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void pnlPanelPlayers_DragDrop(object? sender, DragEventArgs e)
        {
            PlayerCard card = (PlayerCard)e.Data.GetData(typeof(PlayerCard));
            flFavoritesPanel.Controls.Remove(card);
            flPanelPayers.Controls.Add(card);
            card.playerData.IsFavorite = false;
            card.UpdateFavoriteIcon();
        }

        private void btnMovePlayerToFavorites_Click(object sender, EventArgs e)
        {
            var selected = flPanelPayers.Controls
                           .OfType<PlayerCard>()
                           .Where(pc => pc.isSelected)
                           .ToList();


            if (selected.Count + flFavoritesPanel.Controls.Count > 3)
            {
                MessageBox.Show("You can only have up to 3 favorite players.");
                return;
            }

            foreach (var card in selected)
            {
                flPanelPayers.Controls.Remove(card);
                flFavoritesPanel.Controls.Add(card);
                card.playerData.IsFavorite = true;
                card.isSelected = false;
                card.CbSelectPlayer.Checked = false;
                card.UpdateFavoriteIcon();
                UpdateFavorites();
            }
        }

        private void UpdateFavorites()
        {
            favorites.Clear();
            foreach (PlayerCard c in flFavoritesPanel.Controls)
            {
                if (c is PlayerCard card)
                {
                    if (!favorites.Contains(card.playerData))
                    {
                        favorites.Add(card.playerData);
                    }
                }
            }
        }

        private void btnMoveFavoriteToPlayer_Click(object sender, EventArgs e)
        {
            var selected = flFavoritesPanel.Controls
                .OfType<PlayerCard>()
                .Where(pc => pc.isSelected)
                .ToList();

            foreach (var card in selected)
            {
                flFavoritesPanel.Controls.Remove(card);
                card.playerData.IsFavorite = false;
                card.isSelected = false;
                card.CbSelectPlayer.Checked = false;
                flPanelPayers.Controls.Add(card);
                card.UpdateFavoriteIcon();
                UpdateFavorites();
            }
        }

        private async void DashboardForm_Load(object sender, EventArgs e)
        {

            favorites = userSettings.SetFromFavorites();
            var imagePaths = dataService.LoadImagePaths();

            try
            {
                players = await dataService.LoadPlayers(userSettings);
                if (players != null)
                {

                    foreach (Player p in players)
                    {

                        PlayerCard playerControl = new PlayerCard(p);

                        if (imagePaths != null && imagePaths.TryGetValue(p.Name, out string path))
                        {
                            if (File.Exists(path))
                            {
                                playerControl.SetPlayerImage(path);
                                p.ImagePath = path;
                            }
                        }

                        flPanelPayers.Controls.Add(playerControl);
                    }
                }

                foreach (Player p in favorites)
                {
                    flFavoritesPanel.Controls.Add(flPanelPayers.Controls.OfType<PlayerCard>().FirstOrDefault(x => x.playerData.Name == p.Name));
                    flPanelPayers.Controls.Remove(flPanelPayers.Controls.OfType<PlayerCard>().FirstOrDefault(x => x.playerData.Name == p.Name));

                }

                foreach (PlayerCard p in flFavoritesPanel.Controls)
                {
                    p.playerData.IsFavorite = true;
                    p.UpdateFavoriteIcon();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Fatal error. Application can not load players. Application will now close.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DashboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            userSettings.SaveFavorites(favorites);
            userSettings.SaveSettings(userSettings);
        }

        private void tsRankGoals_Click(object sender, EventArgs e)
        {
            RankingList rankingList = new RankingList(players, TypeOfEvent.Goal, userSettings.Representation);
            translation.ApplyTranslations(rankingList);

            rankingList.ShowDialog();
        }

        private void tsRankYellowCards_Click(object sender, EventArgs e)
        {
            RankingList rankingList = new RankingList(players, TypeOfEvent.YellowCard, userSettings.Representation);
            translation.ApplyTranslations(rankingList);
            rankingList.ShowDialog();
        }

        private void tsRankVisitors_Click(object sender, EventArgs e)
        {
            RankingList rankingList = new RankingList(userSettings.Representation);
            translation.ApplyTranslations(rankingList);
            rankingList.ShowDialog();
        }

        //private void tsLabelSettings_Click(object sender, EventArgs e)
        //{
        //    var settingsForm = new LandingForm();
        //    if (settingsForm.ShowDialog() == DialogResult.OK)
        //    {
        //        // Reload dashboard with new settings
        //        var userSettings = UserSettings.SetFromUserSettings();
        //        var newDashboard = new DashboardForm(userSettings);
        //        newDashboard.Show();
        //        this.Close();
        //    }
        //}
    }

}
