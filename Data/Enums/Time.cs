using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DataHandler.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]

    public enum Time
    {
        [EnumMember(Value = "full-time")]
        FullTime
    };
}
