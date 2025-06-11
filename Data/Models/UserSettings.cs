using DataHandler.Models;

namespace OOP.NET_project_KamberInes
{
    public class UserSettings
    {
        private char DELIMITER = '|';
        //private const string PATH_user_settings = "user_settings.txt";
        private static readonly string PATH_user_settings = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\user_settings.txt");

        private const string PATH_user_favorites = "user_favorites.txt";
        public string Language { get; set; }
        public string Representation { get; set; }
        public bool Gender { get; set; } // F = true, M = false
        public string CountryCode { get; set; }

        public override string ToString()
        {
            return $"{Language}{DELIMITER}{Representation}{DELIMITER}{Gender.ToString()}";
        }

        public void SaveSettings(UserSettings userSettings)
        {
            if (!File.Exists(PATH_user_settings))
            {
                File.Create(PATH_user_settings).Close();
            }

            File.WriteAllText(PATH_user_settings, userSettings.ToString());
        }

        public void SaveFavorites(List<Player> players)
        {

            if (!File.Exists(PATH_user_favorites))
            {
                File.Create(PATH_user_favorites).Close();
            }
            File.WriteAllText(PATH_user_favorites, string.Empty);
            foreach (Player player in players)
            {
                if (player.IsFavorite)
                {
                    File.AppendAllText(PATH_user_favorites, player.ToString() + Environment.NewLine);
                }
            }
        }

        public List<Player> SetFromFavorites()
        {
            List<Player> players = new List<Player>();
            if (File.Exists(PATH_user_favorites))
            {
                string[] lines = File.ReadAllLines(PATH_user_favorites);
                if (lines.Length == 0 || string.IsNullOrEmpty(lines[0])) return players;


                foreach (string line in lines)
                {
                    string[] data = line.Split(DELIMITER);

                    Player player = new Player
                    {
                        Name = data[0],
                        ShirtNumber = int.Parse(data[1]),
                        Captain = bool.Parse(data[2]),
                        IsFavorite = true
                    };
                    players.Add(player);
                }
            }
            return players;
        }

        public static UserSettings SetFromUserSettings()
        {
            UserSettings u = new UserSettings();
            if (File.Exists(PATH_user_settings))
            {
                string[] lines = File.ReadAllLines(PATH_user_settings);
                string[] settings = lines[0].Split('|');
                if (settings.Length > 0)
                {
                    if (settings[0] == "hr")
                    {
                        u.Language = "hr";
                    }
                    else
                    {
                        u.Language = "en";
                    }
                    if (settings[2] == "True")
                    {
                        u.Gender = true;
                    }
                    else
                    {
                        u.Gender = false;
                    }

                    u.Representation = settings[1];

                }
                if (!string.IsNullOrEmpty(u.Representation) && u.Representation.Contains("(") && u.Representation.Contains(")"))
                {
                    int start = u.Representation.IndexOf('(');
                    int end = u.Representation.IndexOf(')');
                    if (start != -1 && end != -1 && end > start)
                        u.CountryCode = u.Representation.Substring(start + 1, end - start - 1);
                    else
                        u.CountryCode = string.Empty;
                }
                else
                {
                    u.CountryCode = string.Empty;
                }

            }

            return u;
        }

    }
}
