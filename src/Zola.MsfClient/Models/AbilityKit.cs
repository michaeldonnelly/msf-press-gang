#nullable disable
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zola.MsfClient.Models {
    /// <summary>
    /// A kit of character abilities.
    /// </summary>
    public class AbilityKit : IAdditionalDataHolder, IParsable {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        [NotMapped]
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Information about an ability.</summary>
        public Ability Basic { get; set; }

        /// <summary>Information about an ability.</summary>
        public Ability Passive { get; set; }

        /// <summary>Information about an ability.</summary>
        public Ability Special { get; set; }

        /// <summary>Information about an ability.</summary>
        public Ability Ultimate { get; set; } = new();

        /// <summary>
        /// Instantiates a new AbilityKit and sets the default values.
        /// </summary>
        public AbilityKit() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static AbilityKit CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AbilityKit();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"basic", n => { Basic = n.GetObjectValue<Ability>(Ability.CreateFromDiscriminatorValue); } },
                {"passive", n => { Passive = n.GetObjectValue<Ability>(Ability.CreateFromDiscriminatorValue); } },
                {"special", n => { Special = n.GetObjectValue<Ability>(Ability.CreateFromDiscriminatorValue); } },
                {"ultimate", n => { Ultimate = n.GetObjectValue<Ability>(Ability.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<Ability>("basic", Basic);
            writer.WriteObjectValue<Ability>("passive", Passive);
            writer.WriteObjectValue<Ability>("special", Special);
            writer.WriteObjectValue<Ability>("ultimate", Ultimate);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
