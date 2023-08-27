using System.Runtime.Serialization;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>The functional type of the milestone event.</summary>
    public enum MilestoneEventInfo_type {
        [EnumMember(Value = "solo")]
        Solo,
        [EnumMember(Value = "alliance")]
        Alliance,
    }
}
