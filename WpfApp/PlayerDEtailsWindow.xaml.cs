using DataHandler.Models;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for PlayerDetailsWindow.xaml
    /// </summary>
    public partial class PlayerDetailsWindow : Window
    {
        public PlayerDetailsWindow(Player player)
        {
            InitializeComponent();
            DataContext = player;
        }
    }
}
