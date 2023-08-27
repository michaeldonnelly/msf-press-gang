using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Util.V1.GatedRefresh {
    public class GatedRefresh400Error : ApiException, IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>`INVALID_REQUEST` - The requester didn&apos;t provide valid input.`INVALID_CONTENT_TYPE` - The request body and content type do not match.</summary>
        public GatedRefresh400Error_gatewayError? GatewayError { get; set; }
        /// <summary>
        /// Instantiates a new gatedRefresh400Error and sets the default values.
        /// </summary>
        public GatedRefresh400Error() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static GatedRefresh400Error CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new GatedRefresh400Error();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"gatewayError", n => { GatewayError = n.GetEnumValue<GatedRefresh400Error_gatewayError>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteEnumValue<GatedRefresh400Error_gatewayError>("gatewayError", GatewayError);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
