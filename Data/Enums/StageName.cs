using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DataHandler.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]

    public enum StageName
    {
        [EnumMember(Value = "Final")]
        Final,
        [EnumMember(Value = "First stage")]
        FirstStage,
        [EnumMember(Value = "Play-off for third place")]
        PlayOffForThirdPlace,
        [EnumMember(Value = "Match for third place")]
        MatchForTheThirdPlace,
        [EnumMember(Value = "Quarter-finals")]
        QuarterFinals,
        [EnumMember(Value = "Quarter-final")]
        QuarterFinal,
        [EnumMember(Value = "Round of 16")]
        RoundOf16,
        [EnumMember(Value = "Semi-finals")]
        SemiFinals,
        [EnumMember(Value = "Semi-final")]
        SemiFinal
    };

}
