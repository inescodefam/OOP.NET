using DataHandler.Models;
using Newtonsoft.Json;
using OOP.NET_project_KamberInes;
using RestSharp;

namespace DataHandler
{
    public class DataService
    {
        private const string CONFIG_FILE = "config.txt";

        public static string CONFIG_SETTINGS { get; private set; }
        UserSettings userSettings = new UserSettings();
        private List<Player> players = new();
        private static List<Models.Match> matches = new List<Models.Match>();

        public static async Task<List<Player>> FetchPlayers(string fifaCode, bool isFemaleSelected, string representation)
        {
            matches = await GetMatchesByFifaCode(fifaCode, isFemaleSelected, representation);
            LoadAllMatches();

            string country;

            if (representation.Contains('('))
            {
                country = representation.Substring(0, representation.IndexOf(" (")).Trim();
            }
            else
            {
                country = representation;
            }


            var players = new List<Player>();

            foreach (var match in matches)
            {
                if (string.Equals(match.HomeTeamStatistics?.Country?.Trim(), country, StringComparison.OrdinalIgnoreCase))
                {
                    if (match.HomeTeamStatistics.StartingEleven != null)
                        players.AddRange(match.HomeTeamStatistics.StartingEleven);

                    if (match.HomeTeamStatistics.Substitutes != null)
                        players.AddRange(match.HomeTeamStatistics.Substitutes);
                }

                if (string.Equals(match.AwayTeamStatistics?.Country?.Trim(), country, StringComparison.OrdinalIgnoreCase))
                {
                    if (match.AwayTeamStatistics.StartingEleven != null)
                        players.AddRange(match.AwayTeamStatistics.StartingEleven);

                    if (match.AwayTeamStatistics.Substitutes != null)
                        players.AddRange(match.AwayTeamStatistics.Substitutes);
                }
            }

            var uniquePlayers = players
                .GroupBy(p => new { p.Name, p.ShirtNumber })
                .Select(g => g.First())
                .ToList();

            return uniquePlayers;
        }

        public static List<Match> LoadAllMatches()
        {
            return matches;
        }

        public async Task<List<Player>> LoadPlayers(UserSettings currUserSett)
        {
            try
            {
                return await Task.Run(async () =>
                {
                    players = await FetchPlayers(
                                 currUserSett.CountryCode,
                                 currUserSett.Gender,
                                 currUserSett.Representation);
                    return players;
                });
            }
            catch (Exception e)
            {
                throw new Exception($"Error loading players: {e.Message}");
            }
        }


        public void SaveImagePath(Player playerData, string fullPath)
        {
            var imagePaths = LoadImagePaths();
            imagePaths[playerData.Name] = fullPath;
            File.WriteAllText("imagePaths.json", JsonConvert.SerializeObject(imagePaths));
        }

        public Dictionary<string, string> LoadImagePaths()
        {
            try
            {
                return
                   JsonConvert.DeserializeObject<Dictionary<string, string>>(
                        File.ReadAllText("imagePaths.json")) ?? new Dictionary<string, string>();
            }
            catch (Exception)
            {

                return new Dictionary<string, string>();
            }
        }

        public Dictionary<string, string> LoadImagePathsForWpf()
        {
            try
            {
                return
                   JsonConvert.DeserializeObject<Dictionary<string, string>>(
                        File.ReadAllText(@"../../../../imagePaths.json")) ?? new Dictionary<string, string>();
            }
            catch (Exception)
            {

                return new Dictionary<string, string>();
            }
        }

        public static async Task<List<Match>> GetMatchesByFifaCode(string fifaCode, bool isFemaleSelected, string representation)
        {
            if (File.Exists(CONFIG_FILE))
            {
                CONFIG_SETTINGS = File.ReadAllText(CONFIG_FILE);
            }
            else
            {
                throw new FileNotFoundException($"Configuration file '{CONFIG_FILE}' not found.");
            }

            CONFIG_SETTINGS = File.ReadAllText(CONFIG_FILE);

            string url = isFemaleSelected
                ? Models.Match.MATCH_F_COUNTRY + fifaCode
                : Models.Match.MATCH_M_COUNTRY + fifaCode;
            string dataFilePath = isFemaleSelected
                ? @"C:\Users\Admin\Desktop\Algebra\OOP .NET\OOP.NET-project-KamberInes\DataHandler\JSONFiles\women\matches.json"
                : @"C:\Users\Admin\Desktop\Algebra\OOP .NET\OOP.NET-project-KamberInes\DataHandler\JSONFiles\women\matches.json";

            string country;

            if (representation.Contains('('))
            {
                country = representation.Substring(0, representation.IndexOf(" (")).Trim();
            }
            else
            {
                country = representation;
            }



            if (CONFIG_SETTINGS != "API")
            {
                if (File.Exists(dataFilePath))
                {
                    string jsonData = File.ReadAllText(dataFilePath);
                    try
                    {
                        matches = JsonConvert.DeserializeObject<List<Models.Match>>(jsonData);

                    }
                    catch (Exception)
                    {
                        throw new Exception($"Failed to deserialize JSON data from '{dataFilePath}'.");
                    }
                }
                else
                {
                    throw new FileNotFoundException($"Data file '{dataFilePath}' not found.");
                }
            }
            else
            {

                var options = new RestClientOptions(url)
                {
                    RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
                };
                var client = new RestClient(options);

                var request = new RestRequest();


                try
                {
                    var response = await client.ExecuteAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        matches = JsonConvert.DeserializeObject<List<Models.Match>>(response.Content);
                    }
                    else
                    {
                        throw new Exception($"Failed to fetch data. Status: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"API Error: {ex}");
                    throw;
                }


            }

            return matches
                .Where(m => (m.HomeTeam?.Code == fifaCode || m.AwayTeam?.Code == fifaCode) &&
                            (m.HomeTeam?.Country == country || m.AwayTeam?.Country == country))
                .ToList();
        }

        public static async Task<TeamStatistics?> GetTeamStatistics(string fifaCode, bool isFemaleSelected, string representation)
        {
            matches = await GetMatchesByFifaCode(fifaCode, isFemaleSelected, representation);

            return matches?
                .SelectMany(m => new[] { m.HomeTeamStatistics, m.AwayTeamStatistics })
                .FirstOrDefault(ts => ts != null &&
                    (ts.Country?.Contains(fifaCode, StringComparison.OrdinalIgnoreCase) == true ||
                     matches.Any(m => m.HomeTeam?.Country == representation || m.AwayTeam?.Country == representation)));
        }



    }
}
