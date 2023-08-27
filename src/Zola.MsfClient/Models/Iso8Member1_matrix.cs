using System.Runtime.Serialization;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>The matrix tier. Defaults to green, if omitted.</summary>
    public enum Iso8Member1_matrix {
        [EnumMember(Value = "green")]
        Green,
        [EnumMember(Value = "blue")]
        Blue,
    }
}
