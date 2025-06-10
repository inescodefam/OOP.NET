using Newtonsoft.Json;
using System;

namespace DataHandler.Models
{
    public class TeamsResults
    {

        public static string ENDPOINT = "/teams/results";
        public static string TEAMS_RESULTS_F { get { return URLRouter.BASE_URL_F + ENDPOINT; } }
        public static string TEAMS_RESULTS_M { get { return URLRouter.BASE_URL_M + ENDPOINT; } }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("alternate_name")]
        public object AlternateName { get; set; }

        [JsonProperty("fifa_code")]
        public string FifaCode { get; set; }

        [JsonProperty("group_id")]
        public long GroupId { get; set; }

        [JsonProperty("group_letter")]
        public string GroupLetter { get; set; }

        [JsonProperty("wins")]
        public long Wins { get; set; }

        [JsonProperty("draws")]
        public long Draws { get; set; }

        [JsonProperty("losses")]
        public long Losses { get; set; }

        [JsonProperty("games_played")]
        public long GamesPlayed { get; set; }

        [JsonProperty("points")]
        public long Points { get; set; }

        [JsonProperty("goals_for")]
        public long GoalsFor { get; set; }

        [JsonProperty("goals_against")]
        public long GoalsAgainst { get; set; }

        [JsonProperty("goal_differential")]
        public long GoalDifferential { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is TeamsResults result &&
                   FifaCode == result.FifaCode;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FifaCode);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
