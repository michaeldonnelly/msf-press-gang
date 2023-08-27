using System.Runtime.Serialization;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>The type of node.- `campaign` A campaign node.- `eventCampaign` An event campaign node.- `challenge` A challenge node.- `other` Another kind of node.</summary>
    public enum NodeCompletion_type {
        [EnumMember(Value = "campaign")]
        Campaign,
        [EnumMember(Value = "eventCampaign")]
        EventCampaign,
        [EnumMember(Value = "challenge")]
        Challenge,
        [EnumMember(Value = "other")]
        Other,
    }
}
