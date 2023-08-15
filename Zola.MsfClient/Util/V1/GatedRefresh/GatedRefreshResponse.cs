using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Util.V1.GatedRefresh {
    public class GatedRefreshResponse : IAdditionalDataHolder, IParsable {
        /// <summary>The access_token property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? AccessToken { get; set; }
#nullable restore
#else
        public string AccessToken { get; set; }
#endif
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The expires_in property</summary>
        public double? ExpiresIn { get; set; }
        /// <summary>The id_token property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? IdToken { get; set; }
#nullable restore
#else
        public string IdToken { get; set; }
#endif
        /// <summary>The refresh_token property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? RefreshToken { get; set; }
#nullable restore
#else
        public string RefreshToken { get; set; }
#endif
        /// <summary>The scope property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Scope { get; set; }
#nullable restore
#else
        public string Scope { get; set; }
#endif
        /// <summary>The token_type property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? TokenType { get; set; }
#nullable restore
#else
        public string TokenType { get; set; }
#endif
        /// <summary>
        /// Instantiates a new gatedRefreshResponse and sets the default values.
        /// </summary>
        public GatedRefreshResponse() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static GatedRefreshResponse CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new GatedRefreshResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"access_token", n => { AccessToken = n.GetStringValue(); } },
                {"expires_in", n => { ExpiresIn = n.GetDoubleValue(); } },
                {"id_token", n => { IdToken = n.GetStringValue(); } },
                {"refresh_token", n => { RefreshToken = n.GetStringValue(); } },
                {"scope", n => { Scope = n.GetStringValue(); } },
                {"token_type", n => { TokenType = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("access_token", AccessToken);
            writer.WriteDoubleValue("expires_in", ExpiresIn);
            writer.WriteStringValue("id_token", IdToken);
            writer.WriteStringValue("refresh_token", RefreshToken);
            writer.WriteStringValue("scope", Scope);
            writer.WriteStringValue("token_type", TokenType);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
