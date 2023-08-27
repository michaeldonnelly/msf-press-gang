using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// An error response, including both an Error Object and a Meta Object.Please note that meta hashes will not be available for `RESTARTING` errors and may not be available for other `5xx`-level errors.
    /// </summary>
    public class ErrorResponse : ApiException, IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>An error.400 `BAD_REQUEST` - This is a catchall for unknown situations that are the fault of the request. The request should be tried again only after being corrected.404 `NOT_FOUND` - The requested resource could not be found.422 `PROHIBITED_VALUE` - One or more of the parameters of the request had a value that was not allowed. This could be a parameter by itself (such as asking for level 900) or a parameter in the context of other parameters (such as asking for gear tier 15 for a level 9 character).472 `RESPONSE_TOO_LARGE` - The query is expected to produce a response that is too large. Try specifying parameters in the query to reduce the estimated response size.474 `BANNED` - The request could not be completed because the requesting player is banned.500 `INTERNAL_SERVER_ERROR` - This is a catchall for unknown situations that are the fault of the server. You may try the request again later. If the issue persists, please report it.552 `RESTARTING` - The server is restarting and cannot yet provide a full response to requests. Try again later.553 `MAINTENANCE` - The server is currently in maintenance and cannot provide a full response to requests. Try again later.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Zola.MsfClient.Models.Error? Error { get; set; }
#nullable restore
#else
        public Zola.MsfClient.Models.Error Error { get; set; }
#endif
        /// <summary>Contains meta-information about the response.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Zola.MsfClient.Models.Meta? Meta { get; set; }
#nullable restore
#else
        public Zola.MsfClient.Models.Meta Meta { get; set; }
#endif
        /// <summary>
        /// Instantiates a new ErrorResponse and sets the default values.
        /// </summary>
        public ErrorResponse() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static ErrorResponse CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ErrorResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"error", n => { Error = n.GetObjectValue<Zola.MsfClient.Models.Error>(Zola.MsfClient.Models.Error.CreateFromDiscriminatorValue); } },
                {"meta", n => { Meta = n.GetObjectValue<Zola.MsfClient.Models.Meta>(Zola.MsfClient.Models.Meta.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<Zola.MsfClient.Models.Error>("error", Error);
            writer.WriteObjectValue<Zola.MsfClient.Models.Meta>("meta", Meta);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
