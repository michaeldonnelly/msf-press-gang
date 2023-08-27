using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// An error.400 `BAD_REQUEST` - This is a catchall for unknown situations that are the fault of the request. The request should be tried again only after being corrected.404 `NOT_FOUND` - The requested resource could not be found.422 `PROHIBITED_VALUE` - One or more of the parameters of the request had a value that was not allowed. This could be a parameter by itself (such as asking for level 900) or a parameter in the context of other parameters (such as asking for gear tier 15 for a level 9 character).472 `RESPONSE_TOO_LARGE` - The query is expected to produce a response that is too large. Try specifying parameters in the query to reduce the estimated response size.474 `BANNED` - The request could not be completed because the requesting player is banned.500 `INTERNAL_SERVER_ERROR` - This is a catchall for unknown situations that are the fault of the server. You may try the request again later. If the issue persists, please report it.552 `RESTARTING` - The server is restarting and cannot yet provide a full response to requests. Try again later.553 `MAINTENANCE` - The server is currently in maintenance and cannot provide a full response to requests. Try again later.
    /// </summary>
    public class Error : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The HTTP status code for the error.</summary>
        public int? Code { get; set; }
        /// <summary>The field of the request that triggered the `NOT_FOUND` or `PROHIBITED_VALUE` error.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Field { get; set; }
#nullable restore
#else
        public string Field { get; set; }
#endif
        /// <summary>The estimated length of the response subject to the `RESPONSE_TOO_LARGE` error.</summary>
        public int? Length { get; set; }
        /// <summary>The maximum length of a response for this endpoint (used with the `RESPONSE_TOO_LARGE` error).</summary>
        public int? MaxLength { get; set; }
        /// <summary>A human-readable message describing the error.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Message { get; set; }
#nullable restore
#else
        public string Message { get; set; }
#endif
        /// <summary>The subcode string identifying a particular error.</summary>
        public Error_subcode? Subcode { get; set; }
        /// <summary>
        /// Instantiates a new Error and sets the default values.
        /// </summary>
        public Error() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static Error CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Error();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"code", n => { Code = n.GetIntValue(); } },
                {"field", n => { Field = n.GetStringValue(); } },
                {"length", n => { Length = n.GetIntValue(); } },
                {"maxLength", n => { MaxLength = n.GetIntValue(); } },
                {"message", n => { Message = n.GetStringValue(); } },
                {"subcode", n => { Subcode = n.GetEnumValue<Error_subcode>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("code", Code);
            writer.WriteStringValue("field", Field);
            writer.WriteIntValue("length", Length);
            writer.WriteIntValue("maxLength", MaxLength);
            writer.WriteStringValue("message", Message);
            writer.WriteEnumValue<Error_subcode>("subcode", Subcode);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
