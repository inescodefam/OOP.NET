using DataHandler.Enums;
using Newtonsoft.Json;


namespace DataHandler.Models
{
    public partial class Player
    {
        private const char DELIMITER = '|';
        private const string FILE_PLAYERS = "PLAYERS.txt";
        private const string PATH_PLAYERS = "PlayerImages";
        private const string IMAGE_PATH_DELIMITER = "::";

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public int ShirtNumber { get; set; }

        [JsonProperty("position")]
        public Position Position { get; set; }

        public bool IsFavorite { get; set; } = false;
        [JsonIgnore]
        public object ImagePath { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Player player &&
                   Name == player.Name &&
                   ShirtNumber == player.ShirtNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, ShirtNumber);
        }

        public override string? ToString()
        {
            return $"{Name}{DELIMITER}{ShirtNumber}{DELIMITER}{Captain}{DELIMITER}{IsFavorite}";
        }
    }
}
