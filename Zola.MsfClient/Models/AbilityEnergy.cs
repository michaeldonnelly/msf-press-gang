using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Energy settings for an ability.
    /// </summary>
    public class AbilityEnergy : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>How much energy the ability costs to use. (Default: no override.)</summary>
        public int? CostEnergy { get; set; }
        /// <summary>How much energy the ability starts with. (Default: no override.)</summary>
        public int? StartEnergy { get; set; }
        /// <summary>
        /// Instantiates a new AbilityEnergy and sets the default values.
        /// </summary>
        public AbilityEnergy() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static AbilityEnergy CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AbilityEnergy();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"costEnergy", n => { CostEnergy = n.GetIntValue(); } },
                {"startEnergy", n => { StartEnergy = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("costEnergy", CostEnergy);
            writer.WriteIntValue("startEnergy", StartEnergy);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
