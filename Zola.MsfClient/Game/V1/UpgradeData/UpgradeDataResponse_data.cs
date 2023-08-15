using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using Zola.MsfClient.Models;
namespace Zola.MsfClient.Game.V1.UpgradeData {
    public class UpgradeDataResponse_data : IAdditionalDataHolder, IParsable {
        /// <summary>The abilityLevelRequirements property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public UpgradeDataResponse_data_abilityLevelRequirements? AbilityLevelRequirements { get; set; }
#nullable restore
#else
        public UpgradeDataResponse_data_abilityLevelRequirements AbilityLevelRequirements { get; set; }
#endif
        /// <summary>The abilityUpgradeCosts property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public UpgradeDataResponse_data_abilityUpgradeCosts? AbilityUpgradeCosts { get; set; }
#nullable restore
#else
        public UpgradeDataResponse_data_abilityUpgradeCosts AbilityUpgradeCosts { get; set; }
#endif
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Total XP required to reach that level starting from level 1. (Index 0 is null. Index N is the XP required for level N.)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<int?>? AllianceLevelTotalXp { get; set; }
#nullable restore
#else
        public List<int?> AllianceLevelTotalXp { get; set; }
#endif
        /// <summary>Total XP required to reach that level starting from level 1. (Index 0 is null. Index N is the XP required for level N.)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<int?>? CharacterLevelTotalXp { get; set; }
#nullable restore
#else
        public List<int?> CharacterLevelTotalXp { get; set; }
#endif
        /// <summary>Ways to obtain XP.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<UpgradeDataResponse_data_characterXpCosts>? CharacterXpCosts { get; set; }
#nullable restore
#else
        public List<UpgradeDataResponse_data_characterXpCosts> CharacterXpCosts { get; set; }
#endif
        /// <summary>The iso8AbilityUpgradeCosts property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public UpgradeDataResponse_data_iso8AbilityUpgradeCosts? Iso8AbilityUpgradeCosts { get; set; }
#nullable restore
#else
        public UpgradeDataResponse_data_iso8AbilityUpgradeCosts Iso8AbilityUpgradeCosts { get; set; }
#endif
        /// <summary>The iso8FuseCosts property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public UpgradeDataResponse_data_iso8FuseCosts? Iso8FuseCosts { get; set; }
#nullable restore
#else
        public UpgradeDataResponse_data_iso8FuseCosts Iso8FuseCosts { get; set; }
#endif
        /// <summary>Object mapping level numbers or tier numbers (starting at 1) to level requirements.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public IndexedLevelRequirements? Iso8MatrixLevelRequirements { get; set; }
#nullable restore
#else
        public IndexedLevelRequirements Iso8MatrixLevelRequirements { get; set; }
#endif
        /// <summary>Object mapping level numbers or tier numbers (starting at 1) to costs.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public IndexedCosts? Iso8MatrixUpgradeCosts { get; set; }
#nullable restore
#else
        public IndexedCosts Iso8MatrixUpgradeCosts { get; set; }
#endif
        /// <summary>Total XP required to reach that level starting from level 1. (Index 0 is null. Index N is the XP required for level N.)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<int?>? PlayerLevelTotalXp { get; set; }
#nullable restore
#else
        public List<int?> PlayerLevelTotalXp { get; set; }
#endif
        /// <summary>Object mapping level numbers or tier numbers (starting at 1) to costs.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public IndexedCosts? YellowStarTotalCosts { get; set; }
#nullable restore
#else
        public IndexedCosts YellowStarTotalCosts { get; set; }
#endif
        /// <summary>Object mapping yellow stars (starting at 1) to shards required.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public IndexedShards? YellowStarTotalShards { get; set; }
#nullable restore
#else
        public IndexedShards YellowStarTotalShards { get; set; }
#endif
        /// <summary>
        /// Instantiates a new upgradeDataResponse_data and sets the default values.
        /// </summary>
        public UpgradeDataResponse_data() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static UpgradeDataResponse_data CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new UpgradeDataResponse_data();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"abilityLevelRequirements", n => { AbilityLevelRequirements = n.GetObjectValue<UpgradeDataResponse_data_abilityLevelRequirements>(UpgradeDataResponse_data_abilityLevelRequirements.CreateFromDiscriminatorValue); } },
                {"abilityUpgradeCosts", n => { AbilityUpgradeCosts = n.GetObjectValue<UpgradeDataResponse_data_abilityUpgradeCosts>(UpgradeDataResponse_data_abilityUpgradeCosts.CreateFromDiscriminatorValue); } },
                {"allianceLevelTotalXp", n => { AllianceLevelTotalXp = n.GetCollectionOfPrimitiveValues<int?>()?.ToList(); } },
                {"characterLevelTotalXp", n => { CharacterLevelTotalXp = n.GetCollectionOfPrimitiveValues<int?>()?.ToList(); } },
                {"characterXpCosts", n => { CharacterXpCosts = n.GetCollectionOfObjectValues<UpgradeDataResponse_data_characterXpCosts>(UpgradeDataResponse_data_characterXpCosts.CreateFromDiscriminatorValue)?.ToList(); } },
                {"iso8AbilityUpgradeCosts", n => { Iso8AbilityUpgradeCosts = n.GetObjectValue<UpgradeDataResponse_data_iso8AbilityUpgradeCosts>(UpgradeDataResponse_data_iso8AbilityUpgradeCosts.CreateFromDiscriminatorValue); } },
                {"iso8FuseCosts", n => { Iso8FuseCosts = n.GetObjectValue<UpgradeDataResponse_data_iso8FuseCosts>(UpgradeDataResponse_data_iso8FuseCosts.CreateFromDiscriminatorValue); } },
                {"iso8MatrixLevelRequirements", n => { Iso8MatrixLevelRequirements = n.GetObjectValue<IndexedLevelRequirements>(IndexedLevelRequirements.CreateFromDiscriminatorValue); } },
                {"iso8MatrixUpgradeCosts", n => { Iso8MatrixUpgradeCosts = n.GetObjectValue<IndexedCosts>(IndexedCosts.CreateFromDiscriminatorValue); } },
                {"playerLevelTotalXp", n => { PlayerLevelTotalXp = n.GetCollectionOfPrimitiveValues<int?>()?.ToList(); } },
                {"yellowStarTotalCosts", n => { YellowStarTotalCosts = n.GetObjectValue<IndexedCosts>(IndexedCosts.CreateFromDiscriminatorValue); } },
                {"yellowStarTotalShards", n => { YellowStarTotalShards = n.GetObjectValue<IndexedShards>(IndexedShards.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<UpgradeDataResponse_data_abilityLevelRequirements>("abilityLevelRequirements", AbilityLevelRequirements);
            writer.WriteObjectValue<UpgradeDataResponse_data_abilityUpgradeCosts>("abilityUpgradeCosts", AbilityUpgradeCosts);
            writer.WriteCollectionOfPrimitiveValues<int?>("allianceLevelTotalXp", AllianceLevelTotalXp);
            writer.WriteCollectionOfPrimitiveValues<int?>("characterLevelTotalXp", CharacterLevelTotalXp);
            writer.WriteCollectionOfObjectValues<UpgradeDataResponse_data_characterXpCosts>("characterXpCosts", CharacterXpCosts);
            writer.WriteObjectValue<UpgradeDataResponse_data_iso8AbilityUpgradeCosts>("iso8AbilityUpgradeCosts", Iso8AbilityUpgradeCosts);
            writer.WriteObjectValue<UpgradeDataResponse_data_iso8FuseCosts>("iso8FuseCosts", Iso8FuseCosts);
            writer.WriteObjectValue<IndexedLevelRequirements>("iso8MatrixLevelRequirements", Iso8MatrixLevelRequirements);
            writer.WriteObjectValue<IndexedCosts>("iso8MatrixUpgradeCosts", Iso8MatrixUpgradeCosts);
            writer.WriteCollectionOfPrimitiveValues<int?>("playerLevelTotalXp", PlayerLevelTotalXp);
            writer.WriteObjectValue<IndexedCosts>("yellowStarTotalCosts", YellowStarTotalCosts);
            writer.WriteObjectValue<IndexedShards>("yellowStarTotalShards", YellowStarTotalShards);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
