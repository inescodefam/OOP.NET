using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DataHandler.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]

    public enum TypeOfEvent
    {
        [EnumMember(Value = "goal")]
        Goal,
        [EnumMember(Value = "goal-own")]
        GoalOwn,
        [EnumMember(Value = "goal-penalty")]
        GoalPenalty,
        [EnumMember(Value = "red-card")]
        RedCard,
        [EnumMember(Value = "substitution-in")]
        SubstitutionIn,
        [EnumMember(Value = "substitution-out")]
        SubstitutionOut,
        [EnumMember(Value = "yellow-card")]
        YellowCard,
        [EnumMember(Value = "yellow-card-second")]
        YellowCardSecond
    };
}
