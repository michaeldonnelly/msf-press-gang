using System.Runtime.Serialization;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>Active class id, omitted if no active class.</summary>
    public enum Iso8Member1_active {
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
