using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Information about a raid difficulty.The fields of `enemyAdjustment` are added to the corresponding fields of all enemy CharacterInstance objects in the raid, capped at the values in `enemyCap`. An omitted field means no adjustment or no cap, respectively.The `bonusNodeRewards` are added to every node in the raid.The `bonusCompletionRewardsPerTier` are added to completion rewards, `0` times for the consolation tier, `1` time for the first tier, `2` times for the second tier, and `3` times for the third tier.The `bonusCompletionRewards` are added to completion rewards upon reaching the specified goals.The `bonusAllianceRewards` are rewarded to the alliance upon reaching the specified goals.
    /// </summary>
    public class RaidDifficultyInfo : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Describes an objective including its scoring tiers or ranges.The `progress` field is only present when requesting a player&apos;s progress toward the objective. For raids, the `progress` field represents the alliance&apos;s progress on the raid and the `contribution` field represents the player&apos;s damage contribution.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Objective? BonusAllianceRewards { get; set; }
#nullable restore
#else
        public Objective BonusAllianceRewards { get; set; }
#endif
        /// <summary>Describes an objective including its scoring tiers or ranges.The `progress` field is only present when requesting a player&apos;s progress toward the objective. For raids, the `progress` field represents the alliance&apos;s progress on the raid and the `contribution` field represents the player&apos;s damage contribution.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Objective? BonusCompletionRewards { get; set; }
#nullable restore
#else
        public Objective BonusCompletionRewards { get; set; }
#endif
        /// <summary>A quantity of items (used for rewards).Contains at most one of `item`, `oneOf`, `allOf`, or `chanceOf`.The meaning is as follows:- `item` indicates that particular item.- `oneOf` indicates a package containing a random weighted selection from among its children.- `allOf` indicates a package containing all of its children.- `chanceOf` indicates a package which has a chance of containing its child.If the ItemQuantity object contains none of those four, it represents an empty package.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ItemQuantity? BonusCompletionRewardsPerTier { get; set; }
#nullable restore
#else
        public ItemQuantity BonusCompletionRewardsPerTier { get; set; }
#endif
        /// <summary>A quantity of items (used for rewards).Contains at most one of `item`, `oneOf`, `allOf`, or `chanceOf`.The meaning is as follows:- `item` indicates that particular item.- `oneOf` indicates a package containing a random weighted selection from among its children.- `allOf` indicates a package containing all of its children.- `chanceOf` indicates a package which has a chance of containing its child.If the ItemQuantity object contains none of those four, it represents an empty package.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ItemQuantity? BonusNodeRewards { get; set; }
#nullable restore
#else
        public ItemQuantity BonusNodeRewards { get; set; }
#endif
        /// <summary>The percent completion of the previous difficulty needed to unlock this difficulty.</summary>
        public int? DifficultyUnlock { get; set; }
        /// <summary>An instance of a character (for example, a particular character in a roster, a particular enemy on a raid node, etc.).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public CharacterInstance? EnemyAdjustment { get; set; }
#nullable restore
#else
        public CharacterInstance EnemyAdjustment { get; set; }
#endif
        /// <summary>An instance of a character (for example, a particular character in a roster, a particular enemy on a raid node, etc.).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public CharacterInstance? EnemyCap { get; set; }
#nullable restore
#else
        public CharacterInstance EnemyCap { get; set; }
#endif
        /// <summary>A quantity of items (used for rewards).Contains at most one of `item`, `oneOf`, `allOf`, or `chanceOf`.The meaning is as follows:- `item` indicates that particular item.- `oneOf` indicates a package containing a random weighted selection from among its children.- `allOf` indicates a package containing all of its children.- `chanceOf` indicates a package which has a chance of containing its child.If the ItemQuantity object contains none of those four, it represents an empty package.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ItemQuantity? FirstTimeRewards { get; set; }
#nullable restore
#else
        public ItemQuantity FirstTimeRewards { get; set; }
#endif
        /// <summary>The percent completion of this difficulty needed to unlock the first time rewards.</summary>
        public int? FirstTimeRewardsUnlock { get; set; }
        /// <summary>The limit on the amount of heals allowed for this difficulty. `0` means no heals allowed. If the field is omitted, there is no limit on the amount of heals allowed.</summary>
        public int? HealLimit { get; set; }
        /// <summary>(localized)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Recommendations { get; set; }
#nullable restore
#else
        public string Recommendations { get; set; }
#endif
        /// <summary>Represents requirements.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Zola.MsfClient.Models.Requirements? Requirements { get; set; }
#nullable restore
#else
        public Zola.MsfClient.Models.Requirements Requirements { get; set; }
#endif
        /// <summary>
        /// Instantiates a new RaidDifficultyInfo and sets the default values.
        /// </summary>
        public RaidDifficultyInfo() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static RaidDifficultyInfo CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new RaidDifficultyInfo();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"bonusAllianceRewards", n => { BonusAllianceRewards = n.GetObjectValue<Objective>(Objective.CreateFromDiscriminatorValue); } },
                {"bonusCompletionRewards", n => { BonusCompletionRewards = n.GetObjectValue<Objective>(Objective.CreateFromDiscriminatorValue); } },
                {"bonusCompletionRewardsPerTier", n => { BonusCompletionRewardsPerTier = n.GetObjectValue<ItemQuantity>(ItemQuantity.CreateFromDiscriminatorValue); } },
                {"bonusNodeRewards", n => { BonusNodeRewards = n.GetObjectValue<ItemQuantity>(ItemQuantity.CreateFromDiscriminatorValue); } },
                {"difficultyUnlock", n => { DifficultyUnlock = n.GetIntValue(); } },
                {"enemyAdjustment", n => { EnemyAdjustment = n.GetObjectValue<CharacterInstance>(CharacterInstance.CreateFromDiscriminatorValue); } },
                {"enemyCap", n => { EnemyCap = n.GetObjectValue<CharacterInstance>(CharacterInstance.CreateFromDiscriminatorValue); } },
                {"firstTimeRewards", n => { FirstTimeRewards = n.GetObjectValue<ItemQuantity>(ItemQuantity.CreateFromDiscriminatorValue); } },
                {"firstTimeRewardsUnlock", n => { FirstTimeRewardsUnlock = n.GetIntValue(); } },
                {"healLimit", n => { HealLimit = n.GetIntValue(); } },
                {"recommendations", n => { Recommendations = n.GetStringValue(); } },
                {"requirements", n => { Requirements = n.GetObjectValue<Zola.MsfClient.Models.Requirements>(Zola.MsfClient.Models.Requirements.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<Objective>("bonusAllianceRewards", BonusAllianceRewards);
            writer.WriteObjectValue<Objective>("bonusCompletionRewards", BonusCompletionRewards);
            writer.WriteObjectValue<ItemQuantity>("bonusCompletionRewardsPerTier", BonusCompletionRewardsPerTier);
            writer.WriteObjectValue<ItemQuantity>("bonusNodeRewards", BonusNodeRewards);
            writer.WriteIntValue("difficultyUnlock", DifficultyUnlock);
            writer.WriteObjectValue<CharacterInstance>("enemyAdjustment", EnemyAdjustment);
            writer.WriteObjectValue<CharacterInstance>("enemyCap", EnemyCap);
            writer.WriteObjectValue<ItemQuantity>("firstTimeRewards", FirstTimeRewards);
            writer.WriteIntValue("firstTimeRewardsUnlock", FirstTimeRewardsUnlock);
            writer.WriteIntValue("healLimit", HealLimit);
            writer.WriteStringValue("recommendations", Recommendations);
            writer.WriteObjectValue<Zola.MsfClient.Models.Requirements>("requirements", Requirements);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
