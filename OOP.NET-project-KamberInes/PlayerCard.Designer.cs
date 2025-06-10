namespace OOP.NET_project_KamberInes
{
    partial class PlayerCard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerCard));
            lbFullname = new Label();
            pbFavoriteIcon = new PictureBox();
            lbShirtNumberText = new Label();
            lbShirtNumberValue = new Label();
            pbPlayerImage = new PictureBox();
            lbCapetan = new Label();
            cbSelectPlayer = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pbFavoriteIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPlayerImage).BeginInit();
            SuspendLayout();
            // 
            // lbFullname
            // 
            lbFullname.AutoSize = true;
            lbFullname.BackColor = Color.Transparent;
            lbFullname.Font = new Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            lbFullname.ForeColor = Color.MidnightBlue;
            lbFullname.Location = new Point(3, 102);
            lbFullname.Name = "lbFullname";
            lbFullname.Size = new Size(56, 16);
            lbFullname.TabIndex = 1;
            lbFullname.Text = "FullName";
            // 
            // pbFavoriteIcon
            // 
            pbFavoriteIcon.Image = (Image)resources.GetObject("pbFavoriteIcon.Image");
            pbFavoriteIcon.Location = new Point(97, 136);
            pbFavoriteIcon.Name = "pbFavoriteIcon";
            pbFavoriteIcon.Size = new Size(31, 31);
            pbFavoriteIcon.TabIndex = 2;
            pbFavoriteIcon.TabStop = false;
            // 
            // lbShirtNumberText
            // 
            lbShirtNumberText.AutoSize = true;
            lbShirtNumberText.Font = new Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            lbShirtNumberText.ForeColor = Color.RoyalBlue;
            lbShirtNumberText.Location = new Point(3, 118);
            lbShirtNumberText.Name = "lbShirtNumberText";
            lbShirtNumberText.Size = new Size(67, 16);
            lbShirtNumberText.TabIndex = 3;
            lbShirtNumberText.Text = "ShirtNumer:";
            // 
            // lbShirtNumberValue
            // 
            lbShirtNumberValue.AutoSize = true;
            lbShirtNumberValue.ForeColor = Color.CornflowerBlue;
            lbShirtNumberValue.Location = new Point(105, 117);
            lbShirtNumberValue.Name = "lbShirtNumberValue";
            lbShirtNumberValue.Size = new Size(22, 17);
            lbShirtNumberValue.TabIndex = 4;
            lbShirtNumberValue.Text = "00";
            // 
            // pbPlayerImage
            // 
            pbPlayerImage.BackgroundImage = Properties.Resources.avatar_m;
            pbPlayerImage.Location = new Point(22, 3);
            pbPlayerImage.Name = "pbPlayerImage";
            pbPlayerImage.Size = new Size(95, 96);
            pbPlayerImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbPlayerImage.TabIndex = 5;
            pbPlayerImage.TabStop = false;
            pbPlayerImage.Click += pbPlayerImage_Click;
            // 
            // lbCapetan
            // 
            lbCapetan.AutoSize = true;
            lbCapetan.Font = new Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            lbCapetan.ForeColor = Color.RoyalBlue;
            lbCapetan.Location = new Point(3, 134);
            lbCapetan.Name = "lbCapetan";
            lbCapetan.Size = new Size(58, 16);
            lbCapetan.TabIndex = 6;
            lbCapetan.Text = "Capetan";
            // 
            // cbSelectPlayer
            // 
            cbSelectPlayer.AutoSize = true;
            cbSelectPlayer.ForeColor = Color.RoyalBlue;
            cbSelectPlayer.Location = new Point(3, 153);
            cbSelectPlayer.Name = "cbSelectPlayer";
            cbSelectPlayer.Size = new Size(15, 14);
            cbSelectPlayer.TabIndex = 7;
            cbSelectPlayer.UseVisualStyleBackColor = true;
            cbSelectPlayer.CheckedChanged += cbSelectPlayer_CheckedChanged;
            // 
            // PlayerCard
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.Azure;
            Controls.Add(cbSelectPlayer);
            Controls.Add(lbCapetan);
            Controls.Add(pbPlayerImage);
            Controls.Add(lbShirtNumberValue);
            Controls.Add(lbShirtNumberText);
            Controls.Add(pbFavoriteIcon);
            Controls.Add(lbFullname);
            Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Name = "PlayerCard";
            Size = new Size(130, 170);
            ((System.ComponentModel.ISupportInitialize)pbFavoriteIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPlayerImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lbFullname;
        private PictureBox pbFavoriteIcon;
        private Label lbShirtNumberText;
        private Label lbShirtNumberValue;
        private PictureBox pbPlayerImage;
        private Label lbCapetan;
        private CheckBox cbSelectPlayer;
    }
}
