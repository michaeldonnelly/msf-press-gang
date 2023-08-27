using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Blitz information for an event. (For `blitz` type only.)
    /// </summary>
    public class BlitzEventInfo : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The brackets property</summary>
        public List<Bracket>? Brackets { get; set; }
        /// <summary>Represents requirements.</summary>
        public Zola.MsfClient.Models.Requirements? Requirements { get; set; }

        /// <summary>
        /// Instantiates a new BlitzEventInfo and sets the default values.
        /// </summary>
        public BlitzEventInfo() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static BlitzEventInfo CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new BlitzEventInfo();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"brackets", n => { Brackets = n.GetCollectionOfObjectValues<Bracket>(Bracket.CreateFromDiscriminatorValue)?.ToList(); } },
                {"requirements", n => { Requirements = n.GetObjectValue<Zola.MsfClient.Models.Requirements>(Zola.MsfClient.Models.Requirements.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<Bracket>("brackets", Brackets);
            writer.WriteObjectValue<Zola.MsfClient.Models.Requirements>("requirements", Requirements);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
