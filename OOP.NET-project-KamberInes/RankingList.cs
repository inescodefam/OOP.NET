using DataHandler;
using DataHandler.Enums;
using DataHandler.Models;
using System.Drawing.Printing;

namespace OOP.NET_project_KamberInes
{
    public partial class RankingList : Form
    {
        private const string YELLOW_CARD = "YellowCard";
        private const string GOAL = "Goal";
        private const string GOAL_PENALTY = "GoalPenalty";
        Translation translation = new Translation();

        private PrintDocument printDocument = new PrintDocument();
        private string country = string.Empty;
        public TypeOfEvent Ev { get; }
        public List<Player> Players { get; set; } = new List<Player>();
        private List<Match> matches { get; set; } = new List<Match>();
        Dictionary<string, int> goalsByPlayer = new Dictionary<string, int>();
        Dictionary<string, int> yellowCardsByPlayer = new Dictionary<string, int>();

        public RankingList(List<Player> players, TypeOfEvent typeOfEvent, string representationCoutryCode)
        {
            InitializeComponent();
            Ev = typeOfEvent;
            translation.ApplyTranslations(this);
            country = representationCoutryCode.Split(" (")[0];
            Players = players;
            dgvVisitors.Visible = false;

            printDocument.PrintPage += printDocument_PrintPage;
        }

        public RankingList(string representationCoutryCode)
        {
            InitializeComponent();
            blRankingFullname.Visible = false;
            lbRankingResult.Visible = false;
            translation.ApplyTranslations(this);
            dgvVisitors.Visible = true;
            country = representationCoutryCode.Split(" (")[0];

            printDocument.PrintPage += printDocument_PrintPage;
        }


        private void RankingList_Load(object sender, EventArgs e)
        {
            matches = DataService.LoadAllMatches();

            if (dgvVisitors.Visible)
            {

                List<Match> relevanMatches = new List<Match>();
                foreach (var match in matches)
                {
                    if (match.HomeTeamCountry == country || match.AwayTeamCountry == country)
                    {
                        relevanMatches.Add(match);
                    }
                }

                dgvVisitors.DataSource = relevanMatches.Select(m => new
                {
                    Location = m.Location,
                    Attendance = m.Attendance,
                    HomeTeam = m.HomeTeamCountry,
                    AwayTeam = m.AwayTeamCountry
                }).ToList();
                return;
            }

            foreach (var match in matches)
            {
                foreach (var ev in match.HomeTeamEvents.Concat(match.AwayTeamEvents))
                {
                    if (ev.TypeOfEvent.ToString() == GOAL || ev.TypeOfEvent.ToString() == GOAL_PENALTY)
                    {
                        if (Players.FirstOrDefault(p => p.Name == ev.Player) == null) break;
                        if (!goalsByPlayer.ContainsKey(ev.Player)) goalsByPlayer[ev.Player] = 0;

                        goalsByPlayer[ev.Player]++;
                    }
                    else if (ev.TypeOfEvent.ToString() == YELLOW_CARD)
                    {
                        if (Players.FirstOrDefault(p => p.Name == ev.Player) == null) break;

                        if (!yellowCardsByPlayer.ContainsKey(ev.Player)) yellowCardsByPlayer[ev.Player] = 0;

                        yellowCardsByPlayer[ev.Player]++;
                    }
                }
            }

            // Rang lista golova
            var goalRanking = goalsByPlayer
                .OrderByDescending(x => x.Value)
                .Select(x => new PlayerRanking
                {
                    PlayerName = x.Key,
                    Count = x.Value,
                    ImagePath = Players.FirstOrDefault(p => p.Name == x.Key)?.ImagePath?.ToString()
                })
                .ToList();

            // Rang lista žutih kartona
            var yellowRanking = yellowCardsByPlayer
                .OrderByDescending(x => x.Value)
                .Select(x => new PlayerRanking
                {
                    PlayerName = x.Key,
                    Count = x.Value,
                    ImagePath = Players.FirstOrDefault(p => p.Name == x.Key)?.ImagePath?.ToString()
                })
                .ToList();

            if (Ev == TypeOfEvent.Goal)
            {
                foreach (var player in goalRanking)
                {
                    PlayerRankingControl playerRankingControl = new PlayerRankingControl(player);
                    flRankingPanel.Controls.Add(playerRankingControl);
                }

            }
            else if (Ev == TypeOfEvent.YellowCard)
            {
                foreach (var player in yellowRanking)
                {
                    PlayerRankingControl playerRankingControl = new PlayerRankingControl(player);
                    flRankingPanel.Controls.Add(playerRankingControl);
                }
            }
        }

        // printing
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }

        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (dgvVisitors.Visible)
            {
                Bitmap bm = new Bitmap(this.dgvVisitors.Width, this.dgvVisitors.Height);
                dgvVisitors.DrawToBitmap(bm, new Rectangle(0, 0, this.dgvVisitors.Width, this.dgvVisitors.Height));
                e.Graphics.DrawImage(bm, 0, 0);
                return;
            }
            Bitmap bmp = new Bitmap(flRankingPanel.Width, flRankingPanel.Height, flRankingPanel.CreateGraphics());
            flRankingPanel.DrawToBitmap(bmp, new Rectangle(0, 0, flRankingPanel.Width, flRankingPanel.Height));

            RectangleF bounds = e.PageSettings.PrintableArea;
            float factor = (float)bmp.Height / (float)bmp.Width;
            float printWidth = bounds.Width;
            float printHeight = factor * printWidth;
            if (printHeight > bounds.Height)
            {
                printHeight = bounds.Height;
                printWidth = printHeight / factor;
            }

            e.Graphics.DrawImage(bmp, bounds.Left, bounds.Top, printWidth, printHeight);

        }
    }
}
