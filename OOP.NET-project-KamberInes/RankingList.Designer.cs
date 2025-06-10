namespace OOP.NET_project_KamberInes
{
    partial class RankingList
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RankingList));
            flRankingPanel = new FlowLayoutPanel();
            dgvVisitors = new DataGridView();
            blRankingFullname = new Label();
            lbRankingResult = new Label();
            btnPrint = new Button();
            flRankingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVisitors).BeginInit();
            SuspendLayout();
            // 
            // flRankingPanel
            // 
            flRankingPanel.AutoScroll = true;
            flRankingPanel.BorderStyle = BorderStyle.FixedSingle;
            flRankingPanel.Controls.Add(dgvVisitors);
            flRankingPanel.Location = new Point(2, 29);
            flRankingPanel.Name = "flRankingPanel";
            flRankingPanel.Size = new Size(469, 804);
            flRankingPanel.TabIndex = 0;
            // 
            // dgvVisitors
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.Lavender;
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dataGridViewCellStyle1.ForeColor = Color.DarkBlue;
            dataGridViewCellStyle1.SelectionBackColor = Color.Navy;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvVisitors.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvVisitors.BackgroundColor = Color.Azure;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.Azure;
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            dataGridViewCellStyle2.ForeColor = Color.RoyalBlue;
            dataGridViewCellStyle2.SelectionBackColor = Color.RoyalBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvVisitors.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvVisitors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.Azure;
            dataGridViewCellStyle3.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dataGridViewCellStyle3.ForeColor = Color.RoyalBlue;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvVisitors.DefaultCellStyle = dataGridViewCellStyle3;
            dgvVisitors.Dock = DockStyle.Bottom;
            dgvVisitors.GridColor = Color.RoyalBlue;
            dgvVisitors.Location = new Point(3, 3);
            dgvVisitors.Name = "dgvVisitors";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.Azure;
            dataGridViewCellStyle4.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dataGridViewCellStyle4.ForeColor = Color.RoyalBlue;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvVisitors.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.Azure;
            dataGridViewCellStyle5.Font = new Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dataGridViewCellStyle5.ForeColor = Color.RoyalBlue;
            dgvVisitors.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvVisitors.RowTemplate.Height = 40;
            dgvVisitors.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvVisitors.Size = new Size(440, 797);
            dgvVisitors.TabIndex = 0;
            // 
            // blRankingFullname
            // 
            blRankingFullname.AutoSize = true;
            blRankingFullname.Font = new Font("Century Gothic", 9F);
            blRankingFullname.ForeColor = Color.MidnightBlue;
            blRankingFullname.Location = new Point(132, 9);
            blRankingFullname.Name = "blRankingFullname";
            blRankingFullname.Size = new Size(64, 17);
            blRankingFullname.TabIndex = 1;
            blRankingFullname.Text = "Full name";
            // 
            // lbRankingResult
            // 
            lbRankingResult.AutoSize = true;
            lbRankingResult.Font = new Font("Century Gothic", 9F);
            lbRankingResult.ForeColor = Color.MidnightBlue;
            lbRankingResult.Location = new Point(353, 9);
            lbRankingResult.Name = "lbRankingResult";
            lbRankingResult.Size = new Size(43, 17);
            lbRankingResult.TabIndex = 3;
            lbRankingResult.Text = "Result";
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.Azure;
            btnPrint.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnPrint.ForeColor = Color.RoyalBlue;
            btnPrint.Location = new Point(59, 839);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(367, 23);
            btnPrint.TabIndex = 4;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // RankingList
            // 
            AcceptButton = btnPrint;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(472, 874);
            Controls.Add(btnPrint);
            Controls.Add(lbRankingResult);
            Controls.Add(blRankingFullname);
            Controls.Add(flRankingPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RankingList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ranking";
            TopMost = true;
            Load += RankingList_Load;
            flRankingPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVisitors).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flRankingPanel;
        private Label blRankingFullname;
        private Label lbRankingResult;
        private Button btnPrint;
        private DataGridView dgvVisitors;
    }
}