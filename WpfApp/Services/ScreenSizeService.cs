using System.Windows;

namespace WpfApp.Services
{
    public class ScreenSizeService
    {
        private static int currentScreenSizeOption;
        private static Window window;

        public static int CurrentScreenSizeOption
        {
            get { return currentScreenSizeOption; }
            set
            {
                if (value >= 0 && value <= 4)
                {
                    SetScreenSize(value, window);
                }
            }
        }

        public static void SetScreenSize(int screenSizeOption, Window window)
        {
            currentScreenSizeOption = screenSizeOption;

            window.WindowState = WindowState.Normal;
            switch (screenSizeOption)
            {
                case 0: // 800x450
                    window.Width = 800;
                    window.Height = 450;
                    break;
                case 1: // 1024x768
                    window.Width = 1024;
                    window.Height = 576;
                    break;
                case 2: // 854x480
                    window.Width = 854;
                    window.Height = 480;
                    break;
                case 3://  640x360
                    window.Width = 640;
                    window.Height = 360;
                    break;
                case 4: // fullscreen
                    window.WindowState = System.Windows.WindowState.Maximized;
                    break;
                default:
                    window.Width = 800;
                    window.Height = 450;
                    break;
            }
        }
    }
}
