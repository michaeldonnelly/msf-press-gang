using System.Runtime.Serialization;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>Required ISO-8 class.</summary>
    public enum CharacterFilter_iso8Class {
        [EnumMember(Value = "striker")]
        Striker,
        [EnumMember(Value = "fortifier")]
        Fortifier,
        [EnumMember(Value = "healer")]
        Healer,
        [EnumMember(Value = "skirmisher")]
        Skirmisher,
        [EnumMember(Value = "raider")]
        Raider,
    }
}
