using DataHandler.Models;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for PlayerControl.xaml
    /// </summary>
    public partial class PlayerControl : UserControl
    {
        public event Action<Player> PlayerClicked;

        public PlayerControl(Player player)
        {
            InitializeComponent();
            DataContext = player;
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayerClicked?.Invoke(DataContext as Player);
        }
    }
}
