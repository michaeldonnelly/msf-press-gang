using System.Runtime.Serialization;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>The functional type of the episodic event.</summary>
    public enum EpisodicEventInfo_type {
        [EnumMember(Value = "eventCampaign")]
        EventCampaign,
        [EnumMember(Value = "flashEvent")]
        FlashEvent,
        [EnumMember(Value = "unlockEvent")]
        UnlockEvent,
    }
}
