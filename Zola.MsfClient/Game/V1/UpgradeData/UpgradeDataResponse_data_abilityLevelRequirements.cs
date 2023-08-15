using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using Zola.MsfClient.Models;
namespace Zola.MsfClient.Game.V1.UpgradeData {
    public class UpgradeDataResponse_data_abilityLevelRequirements : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Object mapping level numbers or tier numbers (starting at 1) to level requirements.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public IndexedLevelRequirements? Basic { get; set; }
#nullable restore
#else
        public IndexedLevelRequirements Basic { get; set; }
#endif
        /// <summary>Object mapping level numbers or tier numbers (starting at 1) to level requirements.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public IndexedLevelRequirements? Passive { get; set; }
#nullable restore
#else
        public IndexedLevelRequirements Passive { get; set; }
#endif
        /// <summary>Object mapping level numbers or tier numbers (starting at 1) to level requirements.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public IndexedLevelRequirements? Special { get; set; }
#nullable restore
#else
        public IndexedLevelRequirements Special { get; set; }
#endif
        /// <summary>Object mapping level numbers or tier numbers (starting at 1) to level requirements.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public IndexedLevelRequirements? Ultimate { get; set; }
#nullable restore
#else
        public IndexedLevelRequirements Ultimate { get; set; }
#endif
        /// <summary>
        /// Instantiates a new upgradeDataResponse_data_abilityLevelRequirements and sets the default values.
        /// </summary>
        public UpgradeDataResponse_data_abilityLevelRequirements() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static UpgradeDataResponse_data_abilityLevelRequirements CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new UpgradeDataResponse_data_abilityLevelRequirements();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"basic", n => { Basic = n.GetObjectValue<IndexedLevelRequirements>(IndexedLevelRequirements.CreateFromDiscriminatorValue); } },
                {"passive", n => { Passive = n.GetObjectValue<IndexedLevelRequirements>(IndexedLevelRequirements.CreateFromDiscriminatorValue); } },
                {"special", n => { Special = n.GetObjectValue<IndexedLevelRequirements>(IndexedLevelRequirements.CreateFromDiscriminatorValue); } },
                {"ultimate", n => { Ultimate = n.GetObjectValue<IndexedLevelRequirements>(IndexedLevelRequirements.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<IndexedLevelRequirements>("basic", Basic);
            writer.WriteObjectValue<IndexedLevelRequirements>("passive", Passive);
            writer.WriteObjectValue<IndexedLevelRequirements>("special", Special);
            writer.WriteObjectValue<IndexedLevelRequirements>("ultimate", Ultimate);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
