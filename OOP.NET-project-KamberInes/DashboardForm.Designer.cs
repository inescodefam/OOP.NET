namespace OOP.NET_project_KamberInes
{
    partial class DashboardForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            lbChoosenTeam = new Label();
            lbSelectedRepresentationValue = new Label();
            flPanelPayers = new FlowLayoutPanel();
            lblFavourites = new Label();
            btnMovePlayerToFavorites = new Button();
            btnMoveFavoriteToPlayer = new Button();
            flFavoritesPanel = new FlowLayoutPanel();
            toolStrip = new ToolStrip();
            tsRankGoals = new ToolStripLabel();
            toolStripLabel1 = new ToolStripLabel();
            toolStripSeparator1 = new ToolStripSeparator();
            tsRankYellowCards = new ToolStripLabel();
            toolStripSeparator2 = new ToolStripSeparator();
            tsRankVisitors = new ToolStripLabel();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // lbChoosenTeam
            // 
            lbChoosenTeam.AutoSize = true;
            lbChoosenTeam.BackColor = Color.Transparent;
            lbChoosenTeam.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            lbChoosenTeam.Location = new Point(32, 54);
            lbChoosenTeam.Name = "lbChoosenTeam";
            lbChoosenTeam.Size = new Size(157, 17);
            lbChoosenTeam.TabIndex = 0;
            lbChoosenTeam.Text = "Selected representation:";
            // 
            // lbSelectedRepresentationValue
            // 
            lbSelectedRepresentationValue.AutoSize = true;
            lbSelectedRepresentationValue.BackColor = Color.Transparent;
            lbSelectedRepresentationValue.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            lbSelectedRepresentationValue.ImageAlign = ContentAlignment.MiddleRight;
            lbSelectedRepresentationValue.Location = new Point(407, 54);
            lbSelectedRepresentationValue.Name = "lbSelectedRepresentationValue";
            lbSelectedRepresentationValue.RightToLeft = RightToLeft.No;
            lbSelectedRepresentationValue.Size = new Size(187, 17);
            lbSelectedRepresentationValue.TabIndex = 1;
            lbSelectedRepresentationValue.Text = "selectedRepresentationValue";
            lbSelectedRepresentationValue.TextAlign = ContentAlignment.TopRight;
            // 
            // flPanelPayers
            // 
            flPanelPayers.AllowDrop = true;
            flPanelPayers.AutoScroll = true;
            flPanelPayers.BackColor = Color.Transparent;
            flPanelPayers.BorderStyle = BorderStyle.FixedSingle;
            flPanelPayers.ForeColor = Color.PowderBlue;
            flPanelPayers.Location = new Point(32, 84);
            flPanelPayers.Name = "flPanelPayers";
            flPanelPayers.Size = new Size(562, 532);
            flPanelPayers.TabIndex = 2;
            // 
            // lblFavourites
            // 
            lblFavourites.AutoSize = true;
            lblFavourites.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            lblFavourites.Location = new Point(706, 54);
            lblFavourites.Name = "lblFavourites";
            lblFavourites.Size = new Size(110, 17);
            lblFavourites.TabIndex = 4;
            lblFavourites.Text = "Favourite players";
            // 
            // btnMovePlayerToFavorites
            // 
            btnMovePlayerToFavorites.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnMovePlayerToFavorites.Location = new Point(600, 303);
            btnMovePlayerToFavorites.Name = "btnMovePlayerToFavorites";
            btnMovePlayerToFavorites.Size = new Size(100, 30);
            btnMovePlayerToFavorites.TabIndex = 5;
            btnMovePlayerToFavorites.Text = ">>";
            btnMovePlayerToFavorites.UseVisualStyleBackColor = true;
            btnMovePlayerToFavorites.Click += btnMovePlayerToFavorites_Click;
            // 
            // btnMoveFavoriteToPlayer
            // 
            btnMoveFavoriteToPlayer.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnMoveFavoriteToPlayer.Location = new Point(600, 351);
            btnMoveFavoriteToPlayer.Name = "btnMoveFavoriteToPlayer";
            btnMoveFavoriteToPlayer.Size = new Size(100, 30);
            btnMoveFavoriteToPlayer.TabIndex = 7;
            btnMoveFavoriteToPlayer.Text = "<<";
            btnMoveFavoriteToPlayer.UseVisualStyleBackColor = true;
            btnMoveFavoriteToPlayer.Click += btnMoveFavoriteToPlayer_Click;
            // 
            // flFavoritesPanel
            // 
            flFavoritesPanel.BorderStyle = BorderStyle.FixedSingle;
            flFavoritesPanel.Location = new Point(706, 84);
            flFavoritesPanel.Name = "flFavoritesPanel";
            flFavoritesPanel.Size = new Size(138, 532);
            flFavoritesPanel.TabIndex = 9;
            // 
            // toolStrip
            // 
            toolStrip.Items.AddRange(new ToolStripItem[] { tsRankGoals, toolStripLabel1, toolStripSeparator1, tsRankYellowCards, toolStripSeparator2, tsRankVisitors, toolStripSeparator3 });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(884, 25);
            toolStrip.TabIndex = 10;
            toolStrip.Text = "toolStrip1";
            // 
            // tsRankGoals
            // 
            tsRankGoals.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            tsRankGoals.Name = "tsRankGoals";
            tsRankGoals.Size = new Size(88, 22);
            tsRankGoals.Text = "Rank by goals";
            tsRankGoals.Click += tsRankGoals_Click;
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripLabel1.ImageTransparentColor = Color.Magenta;
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(0, 22);
            toolStripLabel1.Text = "Rank by yellow card";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // tsRankYellowCards
            // 
            tsRankYellowCards.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            tsRankYellowCards.Name = "tsRankYellowCards";
            tsRankYellowCards.Size = new Size(125, 22);
            tsRankYellowCards.Text = "Rank by yellow card";
            tsRankYellowCards.Click += tsRankYellowCards_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // tsRankVisitors
            // 
            tsRankVisitors.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            tsRankVisitors.Name = "tsRankVisitors";
            tsRankVisitors.Size = new Size(160, 22);
            tsRankVisitors.Text = "Rank by number of visitors";
            tsRankVisitors.Click += tsRankVisitors_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(884, 661);
            Controls.Add(toolStrip);
            Controls.Add(flFavoritesPanel);
            Controls.Add(btnMoveFavoriteToPlayer);
            Controls.Add(btnMovePlayerToFavorites);
            Controls.Add(lblFavourites);
            Controls.Add(flPanelPayers);
            Controls.Add(lbSelectedRepresentationValue);
            Controls.Add(lbChoosenTeam);
            Font = new Font("Corbel", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FIFA World Cup Dashboard";
            FormClosing += DashboardForm_FormClosing;
            Load += DashboardForm_Load;
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbChoosenTeam;
        private Label lbSelectedRepresentationValue;
        private FlowLayoutPanel flPanelPayers;
        private Label lblFavourites;
        private Button btnMovePlayerToFavorites;
        private Button btnMoveFavoriteToPlayer;
        private FlowLayoutPanel flFavoritesPanel;
        private ToolStrip toolStrip;
        private ToolStripLabel tsRankGoals;
        private ToolStripLabel toolStripLabel1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel tsRankYellowCards;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel tsRankVisitors;
        private ToolStripSeparator toolStripSeparator3;
    }
}