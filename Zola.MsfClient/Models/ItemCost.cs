using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zola.MsfClient.Models {
    /// <summary>
    /// A cost as a quantity of items.
    /// </summary>
    public class ItemCost : IAdditionalDataHolder, IParsable {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        [NotMapped]
        public IDictionary<string, object> AdditionalData { get; set; }

        /// <summary>If itemFormat=id, just the ID string. Otherwise, the full Item object.</summary>
        public Zola.MsfClient.Models.Item? Item { get; set; }

        /// <summary>Quantity of items.</summary>
        public int? Quantity { get; set; }
        /// <summary>
        /// Instantiates a new ItemCost and sets the default values.
        /// </summary>
        public ItemCost() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static ItemCost CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ItemCost();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"item", n => { Item = n.GetObjectValue<Zola.MsfClient.Models.Item>(Zola.MsfClient.Models.Item.CreateFromDiscriminatorValue); } },
                {"quantity", n => { Quantity = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<Zola.MsfClient.Models.Item>("item", Item);
            writer.WriteIntValue("quantity", Quantity);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
