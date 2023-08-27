using System.Runtime.Serialization;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>The type of the alliance (public or private).</summary>
    public enum AllianceCard_type {
        [EnumMember(Value = "public")]
        Public,
        [EnumMember(Value = "private")]
        Private,
    }
}
