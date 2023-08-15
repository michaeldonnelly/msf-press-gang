using System.Runtime.Serialization;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>Indicates the status of the character.&quot;playable&quot; = Appears in the roster.&quot;summon&quot; = Summoned by another character.&quot;war&quot; = Available in war only.&quot;operator&quot; = Used by either side to progress various missions.&quot;nue&quot; = Used for guided experiences.&quot;model&quot; = Art only.&quot;unplayable&quot; = Cannot be controlled by players in any way.&quot;other&quot; = Doesn&apos;t fit into any of the other categories.&quot;unknown&quot; = Uncategorized, in development, and/or subject to change before release.</summary>
    public enum CharacterInfo_status {
        [EnumMember(Value = "playable")]
        Playable,
        [EnumMember(Value = "summon")]
        Summon,
        [EnumMember(Value = "war")]
        War,
        [EnumMember(Value = "operator")]
        Operator,
        [EnumMember(Value = "nue")]
        Nue,
        [EnumMember(Value = "model")]
        Model,
        [EnumMember(Value = "unplayable")]
        Unplayable,
        [EnumMember(Value = "other")]
        Other,
        [EnumMember(Value = "unknown")]
        Unknown,
    }
}
