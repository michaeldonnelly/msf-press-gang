using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Information about a node. The `introStoryId` is played before character select at that node.
    /// </summary>
    public class NodeInfo : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Describes combat that can occur at a particular node.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public NodeCombat? Combat { get; set; }
#nullable restore
#else
        public NodeCombat Combat { get; set; }
#endif
        /// <summary>The `combatId` of the combat occurring at this node. Can be passed to the `/nodeCombats` route to get the full NodeCombat object for the normal difficulty.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? CombatId { get; set; }
#nullable restore
#else
        public string CombatId { get; set; }
#endif
        /// <summary>(localized) Details shown inline when tapping the info button.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Details { get; set; }
#nullable restore
#else
        public string Details { get; set; }
#endif
        /// <summary>The energy cost for the node.</summary>
        public int? EnergyCost { get; set; }
        /// <summary>A quantity of items (used for rewards).Contains at most one of `item`, `oneOf`, `allOf`, or `chanceOf`.The meaning is as follows:- `item` indicates that particular item.- `oneOf` indicates a package containing a random weighted selection from among its children.- `allOf` indicates a package containing all of its children.- `chanceOf` indicates a package which has a chance of containing its child.If the ItemQuantity object contains none of those four, it represents an empty package.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ItemQuantity? FirstTimeRewards { get; set; }
#nullable restore
#else
        public ItemQuantity FirstTimeRewards { get; set; }
#endif
        /// <summary>A URL.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Icon { get; set; }
#nullable restore
#else
        public string Icon { get; set; }
#endif
        /// <summary>A Story Id. Can be imperfectly mapped to `/localizations/dialog` using `ID_DIALOG_${storyId}_${index}` where index goes from `0` to however many lines there are in the story. The design for this information is incomplete.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? IntroStoryId { get; set; }
#nullable restore
#else
        public string IntroStoryId { get; set; }
#endif
        /// <summary>True if the node is a boss or mini-boss node.</summary>
        public bool? IsBoss { get; set; }
        /// <summary>A quantity of items (used for rewards).Contains at most one of `item`, `oneOf`, `allOf`, or `chanceOf`.The meaning is as follows:- `item` indicates that particular item.- `oneOf` indicates a package containing a random weighted selection from among its children.- `allOf` indicates a package containing all of its children.- `chanceOf` indicates a package which has a chance of containing its child.If the ItemQuantity object contains none of those four, it represents an empty package.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ItemQuantity? LimitedRewards { get; set; }
#nullable restore
#else
        public ItemQuantity LimitedRewards { get; set; }
#endif
        /// <summary>Specifies the limit of how many limited rewards may be obtained from the node. (Typically used for event campaigns.)</summary>
        public int? LimitedRewardsLimit { get; set; }
        /// <summary>(localized)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Name { get; set; }
#nullable restore
#else
        public string Name { get; set; }
#endif
        /// <summary>For raids, instead of the above rewards, a string index identifying the reward type (*e.g.* `standard` or `boss`). This index is for the RaidInfo object&apos;s `nodeRewards` property.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? RaidNodeRewards { get; set; }
#nullable restore
#else
        public string RaidNodeRewards { get; set; }
#endif
        /// <summary>If present, represents additional node-specific requirements to engage the node.If the request is for a specific difficulty or if the node-specific requirements do not vary by difficulty, a single Requirements object is returned.Otherwise, an array of Requirement objects is returned, with index `0` being for normal difficulty and indexes `1`-`N` being for difficulties `1`-`N`, respectively. `null` elements in the array signify no node-specific requirements at that difficulty.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public WithEpisodicType? Requirements { get; set; }
#nullable restore
#else
        public WithEpisodicType Requirements { get; set; }
#endif
        /// <summary>A quantity of items (used for rewards).Contains at most one of `item`, `oneOf`, `allOf`, or `chanceOf`.The meaning is as follows:- `item` indicates that particular item.- `oneOf` indicates a package containing a random weighted selection from among its children.- `allOf` indicates a package containing all of its children.- `chanceOf` indicates a package which has a chance of containing its child.If the ItemQuantity object contains none of those four, it represents an empty package.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ItemQuantity? Rewards { get; set; }
#nullable restore
#else
        public ItemQuantity Rewards { get; set; }
#endif
        /// <summary>The `roomId` of the room reachable from this node by leaving in the northeast direction. (This is the room that is one deeper in the same ray.) Omitted if travel from this room to that room is not possible.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? RoomNE { get; set; }
#nullable restore
#else
        public string RoomNE { get; set; }
#endif
        /// <summary>The `roomId` of the room reachable from this node by leaving in the northwest direction. (This is the room at the same depth in the previous ray.) Omitted if travel from this room to that room is not possible.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? RoomNW { get; set; }
#nullable restore
#else
        public string RoomNW { get; set; }
#endif
        /// <summary>The `roomId` of the room reachable from this node by leaving in the southeast direction. (This is the room at the same depth in the next ray.) Omitted if travel from this room to that room is not possible.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? RoomSE { get; set; }
#nullable restore
#else
        public string RoomSE { get; set; }
#endif
        /// <summary>The `roomId` of the room reachable from this node by leaving in the southwest direction. (This is the room that is one shallower in the same ray.) Omitted if travel from this room to that room is not possible.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? RoomSW { get; set; }
#nullable restore
#else
        public string RoomSW { get; set; }
#endif
        /// <summary>(localized) Short description shown under the name.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? SubName { get; set; }
#nullable restore
#else
        public string SubName { get; set; }
#endif
        /// <summary>
        /// Instantiates a new NodeInfo and sets the default values.
        /// </summary>
        public NodeInfo() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static NodeInfo CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new NodeInfo();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"combat", n => { Combat = n.GetObjectValue<NodeCombat>(NodeCombat.CreateFromDiscriminatorValue); } },
                {"combatId", n => { CombatId = n.GetStringValue(); } },
                {"details", n => { Details = n.GetStringValue(); } },
                {"energyCost", n => { EnergyCost = n.GetIntValue(); } },
                {"firstTimeRewards", n => { FirstTimeRewards = n.GetObjectValue<ItemQuantity>(ItemQuantity.CreateFromDiscriminatorValue); } },
                {"icon", n => { Icon = n.GetStringValue(); } },
                {"introStoryId", n => { IntroStoryId = n.GetStringValue(); } },
                {"isBoss", n => { IsBoss = n.GetBoolValue(); } },
                {"limitedRewards", n => { LimitedRewards = n.GetObjectValue<ItemQuantity>(ItemQuantity.CreateFromDiscriminatorValue); } },
                {"limitedRewardsLimit", n => { LimitedRewardsLimit = n.GetIntValue(); } },
                {"name", n => { Name = n.GetStringValue(); } },
                {"raidNodeRewards", n => { RaidNodeRewards = n.GetStringValue(); } },
                {"requirements", n => { Requirements = n.GetObjectValue<WithEpisodicType>(WithEpisodicType.CreateFromDiscriminatorValue); } },
                {"rewards", n => { Rewards = n.GetObjectValue<ItemQuantity>(ItemQuantity.CreateFromDiscriminatorValue); } },
                {"roomNE", n => { RoomNE = n.GetStringValue(); } },
                {"roomNW", n => { RoomNW = n.GetStringValue(); } },
                {"roomSE", n => { RoomSE = n.GetStringValue(); } },
                {"roomSW", n => { RoomSW = n.GetStringValue(); } },
                {"subName", n => { SubName = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<NodeCombat>("combat", Combat);
            writer.WriteStringValue("combatId", CombatId);
            writer.WriteStringValue("details", Details);
            writer.WriteIntValue("energyCost", EnergyCost);
            writer.WriteObjectValue<ItemQuantity>("firstTimeRewards", FirstTimeRewards);
            writer.WriteStringValue("icon", Icon);
            writer.WriteStringValue("introStoryId", IntroStoryId);
            writer.WriteBoolValue("isBoss", IsBoss);
            writer.WriteObjectValue<ItemQuantity>("limitedRewards", LimitedRewards);
            writer.WriteIntValue("limitedRewardsLimit", LimitedRewardsLimit);
            writer.WriteStringValue("name", Name);
            writer.WriteStringValue("raidNodeRewards", RaidNodeRewards);
            writer.WriteObjectValue<WithEpisodicType>("requirements", Requirements);
            writer.WriteObjectValue<ItemQuantity>("rewards", Rewards);
            writer.WriteStringValue("roomNE", RoomNE);
            writer.WriteStringValue("roomNW", RoomNW);
            writer.WriteStringValue("roomSE", RoomSE);
            writer.WriteStringValue("roomSW", RoomSW);
            writer.WriteStringValue("subName", SubName);
            writer.WriteAdditionalData(AdditionalData);
        }
        /// <summary>
        /// Composed type wrapper for classes Requirements, Requirements
        /// </summary>
        public class WithEpisodicType : IAdditionalDataHolder, IParsable {
            /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
            public IDictionary<string, object> AdditionalData { get; set; }
            /// <summary>Composed type representation for type Requirements</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public Zola.MsfClient.Models.Requirements? Requirements { get; set; }
#nullable restore
#else
            public Zola.MsfClient.Models.Requirements Requirements { get; set; }
#endif
            /// <summary>Serialization hint for the current wrapper.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? SerializationHint { get; set; }
#nullable restore
#else
            public string SerializationHint { get; set; }
#endif
            /// <summary>
            /// Instantiates a new WithEpisodicType and sets the default values.
            /// </summary>
            public WithEpisodicType() {
                AdditionalData = new Dictionary<string, object>();
            }
            /// <summary>
            /// Creates a new instance of the appropriate class based on discriminator value
            /// </summary>
            /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
            public static WithEpisodicType CreateFromDiscriminatorValue(IParseNode parseNode) {
                _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
                var mappingValue = parseNode.GetChildNode("")?.GetStringValue();
                var result = new WithEpisodicType();
                if("Requirements".Equals(mappingValue, StringComparison.OrdinalIgnoreCase)) {
                    result.Requirements = new Zola.MsfClient.Models.Requirements();
                }
                return result;
            }
            /// <summary>
            /// The deserialization information for the current model
            /// </summary>
            public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
                if(Requirements != null) {
                    return Requirements.GetFieldDeserializers();
                }
                return new Dictionary<string, Action<IParseNode>>();
            }
            /// <summary>
            /// Serializes information the current object
            /// </summary>
            /// <param name="writer">Serialization writer to use to serialize this model</param>
            public void Serialize(ISerializationWriter writer) {
                _ = writer ?? throw new ArgumentNullException(nameof(writer));
                if(Requirements != null) {
                    writer.WriteObjectValue<Zola.MsfClient.Models.Requirements>(null, Requirements);
                }
                writer.WriteAdditionalData(AdditionalData);
            }
        }
    }
}
