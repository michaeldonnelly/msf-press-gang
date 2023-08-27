using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Game.V1.Localizations.Item {
    /// <summary>
    /// Instead of xx1 and xx2, the keys correspond to the supported languages returned by the languages route.
    /// </summary>
    public class WithTableResponse_data : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>A URL.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Xx1 { get; set; }
#nullable restore
#else
        public string Xx1 { get; set; }
#endif
        /// <summary>A URL.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Xx2 { get; set; }
#nullable restore
#else
        public string Xx2 { get; set; }
#endif
        /// <summary>
        /// Instantiates a new WithTableResponse_data and sets the default values.
        /// </summary>
        public WithTableResponse_data() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static WithTableResponse_data CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WithTableResponse_data();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"xx1", n => { Xx1 = n.GetStringValue(); } },
                {"xx2", n => { Xx2 = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("xx1", Xx1);
            writer.WriteStringValue("xx2", Xx2);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
