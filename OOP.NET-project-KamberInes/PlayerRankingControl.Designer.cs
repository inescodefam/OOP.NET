namespace OOP.NET_project_KamberInes
{
    partial class PlayerRankingControl
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
            pbPlayerImage = new PictureBox();
            lbFullName = new Label();
            lbResultNumber = new Label();
            ((System.ComponentModel.ISupportInitialize)pbPlayerImage).BeginInit();
            SuspendLayout();
            // 
            // pbPlayerImage
            // 
            pbPlayerImage.BackgroundImage = Properties.Resources.avatar_m;
            pbPlayerImage.Location = new Point(3, 4);
            pbPlayerImage.Name = "pbPlayerImage";
            pbPlayerImage.Size = new Size(95, 96);
            pbPlayerImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbPlayerImage.TabIndex = 6;
            pbPlayerImage.TabStop = false;
            // 
            // lbFullName
            // 
            lbFullName.AutoSize = true;
            lbFullName.ForeColor = Color.RoyalBlue;
            lbFullName.Location = new Point(128, 51);
            lbFullName.Name = "lbFullName";
            lbFullName.Size = new Size(58, 15);
            lbFullName.TabIndex = 7;
            lbFullName.Text = "FullName";
            // 
            // lbResultNumber
            // 
            lbResultNumber.AutoSize = true;
            lbResultNumber.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lbResultNumber.ForeColor = Color.RoyalBlue;
            lbResultNumber.Location = new Point(360, 31);
            lbResultNumber.Name = "lbResultNumber";
            lbResultNumber.Size = new Size(34, 40);
            lbResultNumber.TabIndex = 8;
            lbResultNumber.Text = "0";
            // 
            // PlayerRankingControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            Controls.Add(lbResultNumber);
            Controls.Add(lbFullName);
            Controls.Add(pbPlayerImage);
            Name = "PlayerRankingControl";
            Size = new Size(440, 105);
            ((System.ComponentModel.ISupportInitialize)pbPlayerImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbPlayerImage;
        private Label lbFullName;
        private Label lbResultNumber;
    }
}
