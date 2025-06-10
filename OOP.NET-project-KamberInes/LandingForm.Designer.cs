
namespace OOP.NET_project_KamberInes
{
    partial class LandingForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LandingForm));
            tabControl1 = new TabControl();
            tpLanguage = new TabPage();
            lbChooseLanguage = new Label();
            rbCro = new RadioButton();
            rbEng = new RadioButton();
            tpGender = new TabPage();
            lbChooseChampionship = new Label();
            rbFemale = new RadioButton();
            rbMale = new RadioButton();
            tpTeam = new TabPage();
            lbChooseTeam = new Label();
            cbRepresentation = new ComboBox();
            btnLandingContinue = new Button();
            btnLandingClose = new Button();
            lbWelcome = new Label();
            tabControl1.SuspendLayout();
            tpLanguage.SuspendLayout();
            tpGender.SuspendLayout();
            tpTeam.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpLanguage);
            tabControl1.Controls.Add(tpGender);
            tabControl1.Controls.Add(tpTeam);
            tabControl1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            tabControl1.Location = new Point(255, 111);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(291, 206);
            tabControl1.TabIndex = 0;
            // 
            // tpLanguage
            // 
            tpLanguage.Controls.Add(lbChooseLanguage);
            tpLanguage.Controls.Add(rbCro);
            tpLanguage.Controls.Add(rbEng);
            tpLanguage.Location = new Point(4, 26);
            tpLanguage.Name = "tpLanguage";
            tpLanguage.Padding = new Padding(3);
            tpLanguage.Size = new Size(283, 176);
            tpLanguage.TabIndex = 0;
            tpLanguage.Text = "Language";
            tpLanguage.UseVisualStyleBackColor = true;
            // 
            // lbChooseLanguage
            // 
            lbChooseLanguage.AutoSize = true;
            lbChooseLanguage.Location = new Point(25, 26);
            lbChooseLanguage.Name = "lbChooseLanguage";
            lbChooseLanguage.Size = new Size(116, 17);
            lbChooseLanguage.TabIndex = 2;
            lbChooseLanguage.Text = "Choose language:";
            // 
            // rbCro
            // 
            rbCro.AutoSize = true;
            rbCro.Checked = true;
            rbCro.Location = new Point(94, 105);
            rbCro.Name = "rbCro";
            rbCro.Size = new Size(47, 21);
            rbCro.TabIndex = 1;
            rbCro.TabStop = true;
            rbCro.Text = "Cro";
            rbCro.UseVisualStyleBackColor = true;
            rbCro.CheckedChanged += rbCro_CheckedChanged;
            // 
            // rbEng
            // 
            rbEng.AutoSize = true;
            rbEng.Location = new Point(94, 58);
            rbEng.Name = "rbEng";
            rbEng.Size = new Size(47, 21);
            rbEng.TabIndex = 0;
            rbEng.Text = "Eng";
            rbEng.UseVisualStyleBackColor = true;
            rbEng.CheckedChanged += rbEng_CheckedChanged;
            // 
            // tpGender
            // 
            tpGender.Controls.Add(lbChooseChampionship);
            tpGender.Controls.Add(rbFemale);
            tpGender.Controls.Add(rbMale);
            tpGender.Location = new Point(4, 26);
            tpGender.Name = "tpGender";
            tpGender.Padding = new Padding(3);
            tpGender.Size = new Size(283, 176);
            tpGender.TabIndex = 1;
            tpGender.Text = "Gender";
            tpGender.UseVisualStyleBackColor = true;
            // 
            // lbChooseChampionship
            // 
            lbChooseChampionship.AutoSize = true;
            lbChooseChampionship.Location = new Point(25, 26);
            lbChooseChampionship.Name = "lbChooseChampionship";
            lbChooseChampionship.Size = new Size(235, 17);
            lbChooseChampionship.TabIndex = 5;
            lbChooseChampionship.Text = "Choose male or female championship:";
            // 
            // rbFemale
            // 
            rbFemale.AutoSize = true;
            rbFemale.Location = new Point(94, 105);
            rbFemale.Name = "rbFemale";
            rbFemale.Size = new Size(32, 21);
            rbFemale.TabIndex = 4;
            rbFemale.Text = "F";
            rbFemale.UseVisualStyleBackColor = true;
            rbFemale.CheckedChanged += rbFemale_CheckedChanged;
            // 
            // rbMale
            // 
            rbMale.AutoSize = true;
            rbMale.Checked = true;
            rbMale.Location = new Point(94, 58);
            rbMale.Name = "rbMale";
            rbMale.Size = new Size(37, 21);
            rbMale.TabIndex = 3;
            rbMale.TabStop = true;
            rbMale.Text = "M";
            rbMale.UseVisualStyleBackColor = true;
            rbMale.CheckedChanged += rbMale_CheckedChanged;
            // 
            // tpTeam
            // 
            tpTeam.Controls.Add(lbChooseTeam);
            tpTeam.Controls.Add(cbRepresentation);
            tpTeam.Location = new Point(4, 26);
            tpTeam.Name = "tpTeam";
            tpTeam.Padding = new Padding(3);
            tpTeam.Size = new Size(283, 176);
            tpTeam.TabIndex = 2;
            tpTeam.Text = "Team";
            tpTeam.UseVisualStyleBackColor = true;
            // 
            // lbChooseTeam
            // 
            lbChooseTeam.AutoSize = true;
            lbChooseTeam.Location = new Point(27, 32);
            lbChooseTeam.Name = "lbChooseTeam";
            lbChooseTeam.Size = new Size(91, 17);
            lbChooseTeam.TabIndex = 1;
            lbChooseTeam.Text = "Choose team:";
            // 
            // cbRepresentation
            // 
            cbRepresentation.DropDownHeight = 180;
            cbRepresentation.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRepresentation.FormattingEnabled = true;
            cbRepresentation.IntegralHeight = false;
            cbRepresentation.ItemHeight = 17;
            cbRepresentation.Location = new Point(27, 74);
            cbRepresentation.Name = "cbRepresentation";
            cbRepresentation.Size = new Size(229, 25);
            cbRepresentation.Sorted = true;
            cbRepresentation.TabIndex = 0;
            // 
            // btnLandingContinue
            // 
            btnLandingContinue.BackColor = Color.Transparent;
            btnLandingContinue.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnLandingContinue.Location = new Point(636, 379);
            btnLandingContinue.Name = "btnLandingContinue";
            btnLandingContinue.Size = new Size(152, 35);
            btnLandingContinue.TabIndex = 1;
            btnLandingContinue.Text = "Continue";
            btnLandingContinue.UseVisualStyleBackColor = false;
            btnLandingContinue.Click += btnLandingContinue_Click;
            // 
            // btnLandingClose
            // 
            btnLandingClose.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnLandingClose.Location = new Point(12, 379);
            btnLandingClose.Name = "btnLandingClose";
            btnLandingClose.Size = new Size(152, 35);
            btnLandingClose.TabIndex = 2;
            btnLandingClose.Text = "Cancel";
            btnLandingClose.UseVisualStyleBackColor = true;
            btnLandingClose.Click += btnLandingClose_Click;
            // 
            // lbWelcome
            // 
            lbWelcome.AutoSize = true;
            lbWelcome.BackColor = Color.Transparent;
            lbWelcome.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            lbWelcome.Location = new Point(12, 23);
            lbWelcome.Name = "lbWelcome";
            lbWelcome.Size = new Size(67, 17);
            lbWelcome.TabIndex = 3;
            lbWelcome.Text = "Welcome";
            // 
            // LandingForm
            // 
            AcceptButton = btnLandingContinue;
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._2018_FIFA_World_Cup_Trophy;
            CancelButton = btnLandingClose;
            ClientSize = new Size(800, 429);
            Controls.Add(lbWelcome);
            Controls.Add(btnLandingClose);
            Controls.Add(btnLandingContinue);
            Controls.Add(tabControl1);
            Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LandingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FIFA World Cup - Settings";
            Load += LandingForm_Load;
            tabControl1.ResumeLayout(false);
            tpLanguage.ResumeLayout(false);
            tpLanguage.PerformLayout();
            tpGender.ResumeLayout(false);
            tpGender.PerformLayout();
            tpTeam.ResumeLayout(false);
            tpTeam.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tpLanguage;
        private TabPage tpGender;
        private Label lbChooseLanguage;
        private RadioButton rbCro;
        private RadioButton rbEng;
        private Label lbChooseChampionship;
        private RadioButton rbFemale;
        private RadioButton rbMale;
        private Button btnLandingContinue;
        private Button btnLandingClose;
        private TabPage tpTeam;
        private Label lbChooseTeam;
        private ComboBox cbRepresentation;
        private Label lbWelcome;
    }
}
