using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DataHandler.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Description
    {
        [EnumMember(Value = "Clear Night")]
        ClearNight,
        [EnumMember(Value = "Cloudy")]
        Cloudy,
        [EnumMember(Value = "Partly Cloudy")]
        PartlyCloudy,
        [EnumMember(Value = "Partly Cloudy Night")]
        PartlyCloudyNight,
        [EnumMember(Value = "Cloudy Night")]
        CloudyNight,
        [EnumMember(Value = "Sunny")]
        Sunny
    };

}
