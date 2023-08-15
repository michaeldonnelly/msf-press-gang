using System.Runtime.Serialization;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>Indicates the type of range:- `rank` indicates an absolute rank range like &quot;Rank 21-50&quot;.- `top` indicates a percentage range like &quot;Top 1-2%&quot;.</summary>
    public enum ObjectiveRange_type {
        [EnumMember(Value = "rank")]
        Rank,
        [EnumMember(Value = "top")]
        Top,
    }
}
