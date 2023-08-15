using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using Zola.MsfClient.Models;
namespace Zola.MsfClient.Game.V1.UpgradeData {
    public class UpgradeDataResponse_data_iso8AbilityUpgradeCosts : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Object mapping level numbers or tier numbers (starting at 1) to costs.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public IndexedCosts? Fortifier { get; set; }
#nullable restore
#else
        public IndexedCosts Fortifier { get; set; }
#endif
        /// <summary>Object mapping level numbers or tier numbers (starting at 1) to costs.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public IndexedCosts? Healer { get; set; }
#nullable restore
#else
        public IndexedCosts Healer { get; set; }
#endif
        /// <summary>Object mapping level numbers or tier numbers (starting at 1) to costs.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public IndexedCosts? Raider { get; set; }
#nullable restore
#else
        public IndexedCosts Raider { get; set; }
#endif
        /// <summary>Object mapping level numbers or tier numbers (starting at 1) to costs.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public IndexedCosts? Skirmisher { get; set; }
#nullable restore
#else
        public IndexedCosts Skirmisher { get; set; }
#endif
        /// <summary>Object mapping level numbers or tier numbers (starting at 1) to costs.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public IndexedCosts? Striker { get; set; }
#nullable restore
#else
        public IndexedCosts Striker { get; set; }
#endif
        /// <summary>
        /// Instantiates a new upgradeDataResponse_data_iso8AbilityUpgradeCosts and sets the default values.
        /// </summary>
        public UpgradeDataResponse_data_iso8AbilityUpgradeCosts() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static UpgradeDataResponse_data_iso8AbilityUpgradeCosts CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new UpgradeDataResponse_data_iso8AbilityUpgradeCosts();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"fortifier", n => { Fortifier = n.GetObjectValue<IndexedCosts>(IndexedCosts.CreateFromDiscriminatorValue); } },
                {"healer", n => { Healer = n.GetObjectValue<IndexedCosts>(IndexedCosts.CreateFromDiscriminatorValue); } },
                {"raider", n => { Raider = n.GetObjectValue<IndexedCosts>(IndexedCosts.CreateFromDiscriminatorValue); } },
                {"skirmisher", n => { Skirmisher = n.GetObjectValue<IndexedCosts>(IndexedCosts.CreateFromDiscriminatorValue); } },
                {"striker", n => { Striker = n.GetObjectValue<IndexedCosts>(IndexedCosts.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<IndexedCosts>("fortifier", Fortifier);
            writer.WriteObjectValue<IndexedCosts>("healer", Healer);
            writer.WriteObjectValue<IndexedCosts>("raider", Raider);
            writer.WriteObjectValue<IndexedCosts>("skirmisher", Skirmisher);
            writer.WriteObjectValue<IndexedCosts>("striker", Striker);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
