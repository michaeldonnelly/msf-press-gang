using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Object mapping difficulty numbers (starting at 1) to RaidDifficultyInfo objects.
    /// </summary>
    public class IndexedRaidDifficultyInfos : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Information about a raid difficulty.The fields of `enemyAdjustment` are added to the corresponding fields of all enemy CharacterInstance objects in the raid, capped at the values in `enemyCap`. An omitted field means no adjustment or no cap, respectively.The `bonusNodeRewards` are added to every node in the raid.The `bonusCompletionRewardsPerTier` are added to completion rewards, `0` times for the consolation tier, `1` time for the first tier, `2` times for the second tier, and `3` times for the third tier.The `bonusCompletionRewards` are added to completion rewards upon reaching the specified goals.The `bonusAllianceRewards` are rewarded to the alliance upon reaching the specified goals.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RaidDifficultyInfo? Pound { get; set; }
#nullable restore
#else
        public RaidDifficultyInfo Pound { get; set; }
#endif
        /// <summary>
        /// Instantiates a new IndexedRaidDifficultyInfos and sets the default values.
        /// </summary>
        public IndexedRaidDifficultyInfos() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static IndexedRaidDifficultyInfos CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new IndexedRaidDifficultyInfos();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"#", n => { Pound = n.GetObjectValue<RaidDifficultyInfo>(RaidDifficultyInfo.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<RaidDifficultyInfo>("#", Pound);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
