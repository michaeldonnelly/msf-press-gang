using System.Runtime.Serialization;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>A rank in an alliance.</summary>
    public enum AllianceRank {
        [EnumMember(Value = "leader")]
        Leader,
        [EnumMember(Value = "captain")]
        Captain,
        [EnumMember(Value = "member")]
        Member,
    }
}
