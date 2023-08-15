using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zola.MsfClient.Models {
    /// <summary>
    /// Object mapping tier numbers (starting at 1) to GearTier objects.
    /// </summary>
    public class IndexedGearTiers : IAdditionalDataHolder, IParsable {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        [NotMapped]
        public IDictionary<string, object> AdditionalData { get; set; }

        /// <summary>Information about a tier of gear for a character.</summary>
        public GearTier? Pound { get; set; }

        /// <summary>
        /// Instantiates a new IndexedGearTiers and sets the default values.
        /// </summary>
        public IndexedGearTiers() {
            AdditionalData = new Dictionary<string, object>();
        }

        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static IndexedGearTiers CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new IndexedGearTiers();
        }

        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"#", n => { Pound = n.GetObjectValue<GearTier>(GearTier.CreateFromDiscriminatorValue); } },
            };
        }

        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<GearTier>("#", Pound);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
