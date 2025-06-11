using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MatchDetailsWindow.xaml
    /// </summary>
    public partial class MatchDetailsWindow : Window
    {
        public MatchDetailsWindow(DataHandler.Models.TeamsResults selectedHome, DataHandler.Models.TeamsResults selectedGuest)
        {
            InitializeComponent();
        }
    }
}
