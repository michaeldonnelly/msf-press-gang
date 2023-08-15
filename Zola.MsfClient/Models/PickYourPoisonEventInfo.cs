using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Pick Your Poison information for an event. (For `pickYourPoison` type only.)
    /// </summary>
    public class PickYourPoisonEventInfo : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The brackets property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Bracket>? Brackets { get; set; }
#nullable restore
#else
        public List<Bracket> Brackets { get; set; }
#endif
        /// <summary>(localized)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? TypeName { get; set; }
#nullable restore
#else
        public string TypeName { get; set; }
#endif
        /// <summary>
        /// Instantiates a new PickYourPoisonEventInfo and sets the default values.
        /// </summary>
        public PickYourPoisonEventInfo() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static PickYourPoisonEventInfo CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new PickYourPoisonEventInfo();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"brackets", n => { Brackets = n.GetCollectionOfObjectValues<Bracket>(Bracket.CreateFromDiscriminatorValue)?.ToList(); } },
                {"typeName", n => { TypeName = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<Bracket>("brackets", Brackets);
            writer.WriteStringValue("typeName", TypeName);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
