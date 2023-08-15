using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Composed type wrapper for classes string, Iso8Member1
    /// </summary>
    public class Iso8 : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Composed type representation for type Iso8Member1</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Zola.MsfClient.Models.Iso8Member1? Iso8Member1 { get; set; }
#nullable restore
#else
        public Zola.MsfClient.Models.Iso8Member1 Iso8Member1 { get; set; }
#endif
        /// <summary>Serialization hint for the current wrapper.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? SerializationHint { get; set; }
#nullable restore
#else
        public string SerializationHint { get; set; }
#endif
        /// <summary>Composed type representation for type string</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? String { get; set; }
#nullable restore
#else
        public string String { get; set; }
#endif
        /// <summary>
        /// Instantiates a new Iso8 and sets the default values.
        /// </summary>
        public Iso8() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static Iso8 CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("")?.GetStringValue();
            var result = new Iso8();
            if("".Equals(mappingValue, StringComparison.OrdinalIgnoreCase)) {
                result.Iso8Member1 = new Zola.MsfClient.Models.Iso8Member1();
            }
            else if(parseNode.GetStringValue() is string stringValue) {
                result.String = stringValue;
            }
            return result;
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            if(Iso8Member1 != null) {
                return Iso8Member1.GetFieldDeserializers();
            }
            return new Dictionary<string, Action<IParseNode>>();
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            if(Iso8Member1 != null) {
                writer.WriteObjectValue<Zola.MsfClient.Models.Iso8Member1>(null, Iso8Member1);
            }
            else if(String != null) {
                writer.WriteStringValue(null, String);
            }
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
