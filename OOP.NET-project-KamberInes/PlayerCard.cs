using DataHandler;
using DataHandler.Models;

namespace OOP.NET_project_KamberInes
{
    public partial class PlayerCard : UserControl
    {
        private Translation translation = new();

        public Player playerData;
        public bool isSelected = false;
        public CheckBox CbSelectPlayer => this.cbSelectPlayer;
        DataService dataService = new DataService();


        public PlayerCard(Player playerData)
        {
            InitializeComponent();
            translation.ApplyTranslations(this);

            this.playerData = playerData;
            lbFullname.Text = playerData.Name;
            lbCapetan.Visible = playerData.Captain;
            lbShirtNumberValue.Text = playerData.ShirtNumber.ToString();
            pbFavoriteIcon.Visible = playerData.IsFavorite;
            cbSelectPlayer.CheckedChanged += cbSelectPlayer_CheckedChanged;
        }

        public void UpdateFavoriteIcon()
        {
            pbFavoriteIcon.Visible = playerData.IsFavorite;
        }

        public void SelectPlayer()
        {
            if (isSelected)
            {
                this.BackColor = Color.Transparent;

            }
            else
            {
                this.BackColor = Color.Azure;

            }
        }

        public void cbSelectPlayer_CheckedChanged(object sender, EventArgs e)
        {
            this.isSelected = cbSelectPlayer.Checked;
            this.SelectPlayer();
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                this.DoDragDrop(this, DragDropEffects.Move);
            }
        }

        private void pbPlayerImage_Click(object sender, EventArgs e) // refactor
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string playerName = lbFullname.Text;
                string playerShirtNumber = lbShirtNumberValue.Text;
                string imagePath = Path.Combine(Environment.CurrentDirectory, "PlayerImage");
                string imageFileName = $"{playerName}.jpg";
                string fullPath = Path.Combine(imagePath, imageFileName);

                if (!Directory.Exists(imagePath))
                    Directory.CreateDirectory(imagePath);

                Directory.CreateDirectory(imagePath);
                File.Copy(ofd.FileName, fullPath, true);

                pbPlayerImage.Image?.Dispose();
                pbPlayerImage.Image = null;
                pbPlayerImage.Image = Image.FromFile(ofd.FileName);

                dataService.SaveImagePath(playerData,
                                          fullPath);
            }

        }

        public void SetPlayerImage(string imagePath)
        {
            if (File.Exists(imagePath))
            {
                pbPlayerImage.Image?.Dispose();
                pbPlayerImage.Image = null;
                pbPlayerImage.Image = Image.FromFile(imagePath);
            }
        }

    }
}
