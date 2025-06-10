using DataHandler.Models;

namespace OOP.NET_project_KamberInes
{
    public partial class PlayerRankingControl : UserControl
    {
        public PlayerRankingControl(PlayerRanking playerRanking)
        {
            InitializeComponent();
            lbFullName.Text = playerRanking.PlayerName;
            lbResultNumber.Text = playerRanking.Count.ToString();
            if (playerRanking.ImagePath != null)
            {
                pbPlayerImage.Image = Image.FromFile(playerRanking.ImagePath);
                pbPlayerImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
