using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Information about a raid or dark dimension.Raid completion rewards are returned in the `completion` property, with consolation rewards in tier 0.Dark dimension completion rewards are returned in the `ddCompletion` property, with first time rewards in the 100% tier and second time rewards (first *timed* completion) in the 200% tier.
    /// </summary>
    public class RaidInfo : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The number of combat nodes per strike team. (Thus `teams * combatNodesPerTeam` gives the total number of combat nodes in the whole raid.)</summary>
        public int? CombatNodesPerTeam { get; set; }
        /// <summary>Describes an objective including its scoring tiers or ranges.The `progress` field is only present when requesting a player&apos;s progress toward the objective. For raids, the `progress` field represents the alliance&apos;s progress on the raid and the `contribution` field represents the player&apos;s damage contribution.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Objective? Completion { get; set; }
#nullable restore
#else
        public Objective Completion { get; set; }
#endif
        /// <summary>Describes an objective including its scoring tiers or ranges.The `progress` field is only present when requesting a player&apos;s progress toward the objective. For raids, the `progress` field represents the alliance&apos;s progress on the raid and the `contribution` field represents the player&apos;s damage contribution.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Objective? DdCompletion { get; set; }
#nullable restore
#else
        public Objective DdCompletion { get; set; }
#endif
        /// <summary>(localized) Details shown inline when tapping the info button.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Details { get; set; }
#nullable restore
#else
        public string Details { get; set; }
#endif
        /// <summary>Object mapping difficulty numbers (starting at 1) to RaidDifficultyInfo objects.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public IndexedRaidDifficultyInfos? Difficulties { get; set; }
#nullable restore
#else
        public IndexedRaidDifficultyInfos Difficulties { get; set; }
#endif
        /// <summary>The ID of the raid group to which this raid belongs.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? GroupId { get; set; }
#nullable restore
#else
        public string GroupId { get; set; }
#endif
        /// <summary>The number of hours allowed to complete the raid.</summary>
        public int? Hours { get; set; }
        /// <summary>The ID of this raid or dark dimension.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Id { get; set; }
#nullable restore
#else
        public string Id { get; set; }
#endif
        /// <summary>The number of keys required to start the raid.</summary>
        public int? KeyCost { get; set; }
        /// <summary>The number of difficulties beyond normal currently available. If omitted, no additional difficulties are available.</summary>
        public int? MaxDifficulty { get; set; }
        /// <summary>The maximum number of players that can join each strike team. (Thus `teams * maxPlayersPerTeam` gives the total number of players that can participate in the raid.)</summary>
        public int? MaxPlayersPerTeam { get; set; }
        /// <summary>(localized)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Name { get; set; }
#nullable restore
#else
        public string Name { get; set; }
#endif
        /// <summary>Object mapping `rewardType`s (*e.g.* `standard` or `boss`) to ItemQuantity objects.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public MappedRewards? NodeRewards { get; set; }
#nullable restore
#else
        public MappedRewards NodeRewards { get; set; }
#endif
        /// <summary>The number of rays in the raid or dark dimension map.Rays run from the southwest to the northeast.Typically, rooms in the same ray start with the same letter and increase in number, *e.g.* `A1`, `A2`, *etc.*.So, typically, the number of rays is equal to the number of letters used for `roomId`s.</summary>
        public int? RayCount { get; set; }
        /// <summary>The depth of each ray in the raid or dark dimension map.Rays run from the southwest to the northeast.Typically, rooms in the same ray start with the same letter and increase in number, *e.g.* `A1`, `A2`, *etc.*.So, typically, the depth of each ray is equal to the number of numbers used for `roomId`s.</summary>
        public int? RayDepth { get; set; }
        /// <summary>An array of rays, each ray being an array of `roomId` strings, *e.g.* `&quot;A1&quot;`. (`&quot;&quot;` indicates no room at that position in the ray.)Each ray run from the southwest to the northeast.The first ray is the northwest-most ray and the last row is the southeast-most ray.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? Rays { get; set; }
#nullable restore
#else
        public List<string> Rays { get; set; }
#endif
        /// <summary>Object mapping `roomId`s to NodeInfo objects.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public MappedNodeInfos? Rooms { get; set; }
#nullable restore
#else
        public MappedNodeInfos Rooms { get; set; }
#endif
        /// <summary>The `roomId` at which all players start.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? StartingRoomId { get; set; }
#nullable restore
#else
        public string StartingRoomId { get; set; }
#endif
        /// <summary>(localized) Short description shown under the name.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? SubName { get; set; }
#nullable restore
#else
        public string SubName { get; set; }
#endif
        /// <summary>The number of strike teams in the raid.</summary>
        public int? Teams { get; set; }
        /// <summary>
        /// Instantiates a new RaidInfo and sets the default values.
        /// </summary>
        public RaidInfo() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static RaidInfo CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new RaidInfo();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"combatNodesPerTeam", n => { CombatNodesPerTeam = n.GetIntValue(); } },
                {"completion", n => { Completion = n.GetObjectValue<Objective>(Objective.CreateFromDiscriminatorValue); } },
                {"ddCompletion", n => { DdCompletion = n.GetObjectValue<Objective>(Objective.CreateFromDiscriminatorValue); } },
                {"details", n => { Details = n.GetStringValue(); } },
                {"difficulties", n => { Difficulties = n.GetObjectValue<IndexedRaidDifficultyInfos>(IndexedRaidDifficultyInfos.CreateFromDiscriminatorValue); } },
                {"groupId", n => { GroupId = n.GetStringValue(); } },
                {"hours", n => { Hours = n.GetIntValue(); } },
                {"id", n => { Id = n.GetStringValue(); } },
                {"keyCost", n => { KeyCost = n.GetIntValue(); } },
                {"maxDifficulty", n => { MaxDifficulty = n.GetIntValue(); } },
                {"maxPlayersPerTeam", n => { MaxPlayersPerTeam = n.GetIntValue(); } },
                {"name", n => { Name = n.GetStringValue(); } },
                {"nodeRewards", n => { NodeRewards = n.GetObjectValue<MappedRewards>(MappedRewards.CreateFromDiscriminatorValue); } },
                {"rayCount", n => { RayCount = n.GetIntValue(); } },
                {"rayDepth", n => { RayDepth = n.GetIntValue(); } },
                {"rays", n => { Rays = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"rooms", n => { Rooms = n.GetObjectValue<MappedNodeInfos>(MappedNodeInfos.CreateFromDiscriminatorValue); } },
                {"startingRoomId", n => { StartingRoomId = n.GetStringValue(); } },
                {"subName", n => { SubName = n.GetStringValue(); } },
                {"teams", n => { Teams = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("combatNodesPerTeam", CombatNodesPerTeam);
            writer.WriteObjectValue<Objective>("completion", Completion);
            writer.WriteObjectValue<Objective>("ddCompletion", DdCompletion);
            writer.WriteStringValue("details", Details);
            writer.WriteObjectValue<IndexedRaidDifficultyInfos>("difficulties", Difficulties);
            writer.WriteStringValue("groupId", GroupId);
            writer.WriteIntValue("hours", Hours);
            writer.WriteStringValue("id", Id);
            writer.WriteIntValue("keyCost", KeyCost);
            writer.WriteIntValue("maxDifficulty", MaxDifficulty);
            writer.WriteIntValue("maxPlayersPerTeam", MaxPlayersPerTeam);
            writer.WriteStringValue("name", Name);
            writer.WriteObjectValue<MappedRewards>("nodeRewards", NodeRewards);
            writer.WriteIntValue("rayCount", RayCount);
            writer.WriteIntValue("rayDepth", RayDepth);
            writer.WriteCollectionOfPrimitiveValues<string>("rays", Rays);
            writer.WriteObjectValue<MappedNodeInfos>("rooms", Rooms);
            writer.WriteStringValue("startingRoomId", StartingRoomId);
            writer.WriteStringValue("subName", SubName);
            writer.WriteIntValue("teams", Teams);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
