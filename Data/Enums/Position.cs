using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DataHandler.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]

    public enum Position {
        [EnumMember(Value = "Defender")]
        Defender,
        [EnumMember(Value = "Forward")]
        Forward,
        [EnumMember(Value = "Goalie")]
        Goalie,
        [EnumMember(Value = "Midfield")]
        Midfield };
}
