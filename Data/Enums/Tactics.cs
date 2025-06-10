﻿using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DataHandler.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]

    public enum Tactics
    {
        [EnumMember(Value = "3-4-2-1")]
        The3421,
        [EnumMember(Value = "3-4-3")]
        The343,
        [EnumMember(Value = "3-5-2")]
        The352,
        [EnumMember(Value = "4-2-3-1")]
        The4231,
        [EnumMember(Value = "4-3-2-1")]
        The4321,
        [EnumMember(Value = "4-3-3")]
        The433,
        [EnumMember(Value = "4-4-2")]
        The442,
        [EnumMember(Value = "4-5-1")]
        The451,
        [EnumMember(Value = "5-3-2")]
        The532,
        [EnumMember(Value = "5-4-1")]
        The541,
    };
}
