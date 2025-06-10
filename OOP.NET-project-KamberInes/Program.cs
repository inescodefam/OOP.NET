namespace OOP.NET_project_KamberInes
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new LandingForm());

            //// this is the main form of the application

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            //var userSettings = UserSettings.SetFromUserSettings();
            //if (userSettings == null || string.IsNullOrEmpty(userSettings.Representation))
            //{
            //    // No settings, show settings form first
            //    Application.Run(new LandingForm());
            //}
            //else
            //{
            //    // Settings exist, go directly to dashboard
            //    Application.Run(new DashboardForm(userSettings));
            //}
        }
    }
}