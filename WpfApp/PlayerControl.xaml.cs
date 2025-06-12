using DataHandler.Models;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

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

            var animation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromMilliseconds(500d)
            };
            this.BeginAnimation(OpacityProperty, animation, System.Windows.Media.Animation.HandoffBehavior.Compose);

            var rotateAnimation = new DoubleAnimation
            {
                From = 0,
                To = 360,
                Duration = TimeSpan.FromMilliseconds(500),
            };

            var rotateTransform = this.RenderTransform as RotateTransform;
            if (rotateTransform != null)
            {
                rotateTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);
            }
        }
    }
}
