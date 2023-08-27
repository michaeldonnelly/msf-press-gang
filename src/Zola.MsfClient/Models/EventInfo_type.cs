using System.Runtime.Serialization;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>The type of event.</summary>
    public enum EventInfo_type {
        [EnumMember(Value = "info")]
        Info,
        [EnumMember(Value = "bonus")]
        Bonus,
        [EnumMember(Value = "blitz")]
        Blitz,
        [EnumMember(Value = "episodic")]
        Episodic,
        [EnumMember(Value = "milestone")]
        Milestone,
        [EnumMember(Value = "raid")]
        Raid,
        [EnumMember(Value = "raidSeason")]
        RaidSeason,
        [EnumMember(Value = "warSeason")]
        WarSeason,
        [EnumMember(Value = "donation")]
        Donation,
        [EnumMember(Value = "battlePass")]
        BattlePass,
        [EnumMember(Value = "strikePass")]
        StrikePass,
        [EnumMember(Value = "tower")]
        Tower,
        [EnumMember(Value = "pickYourPoison")]
        PickYourPoison,
    }
}
