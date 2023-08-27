using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Contains meta-information about the response.
    /// </summary>
    public class Meta : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>A value that can be passed to a future request&apos;s `since` parameter to identify the current response.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? AsOf { get; set; }
#nullable restore
#else
        public string AsOf { get; set; }
#endif
        /// <summary>These hashes will change when the underlying **non-player** data returnable by the API changes.If the hash value pertinent to a response is cached with the response, finding a different value for that hash on a future response can be used to invalidate the previously cached response.For example, if a request for CITY characters returns a &quot;chars&quot; hash of &quot;6b4&quot; and a later request for an alpha raid node returns a &quot;chars&quot; hash of &quot;6b4&quot;, there is no need to refresh the list of CITY characters. However, if the later request for an alpha raid node returns a &quot;chars&quot; hash of &quot;1b8&quot;, then the list of CITY characters has potentially been updated.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Meta_hashes? Hashes { get; set; }
#nullable restore
#else
        public Meta_hashes Hashes { get; set; }
#endif
        /// <summary>For paged results, indicates the page number of the returned results, with `1` being the first page.For results numbered `1` through `perTotal`, page `n` will contain results numbered `(perPage * (n - 1)) + 1` through `perPage * n`.</summary>
        public int? Page { get; set; }
        /// <summary>For paged results, indicates the number of results per page.</summary>
        public int? PerPage { get; set; }
        /// <summary>For paged results, indicates the total number of results across all pages.</summary>
        public int? PerTotal { get; set; }
        /// <summary>A date and time expressed as seconds since 1970 UTC.</summary>
        public long? RefreshAt { get; set; }
        /// <summary>The version of the API. Currently 1.</summary>
        public int? Version { get; set; }
        /// <summary>
        /// Instantiates a new Meta and sets the default values.
        /// </summary>
        public Meta() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static Meta CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Meta();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"asOf", n => { AsOf = n.GetStringValue(); } },
                {"hashes", n => { Hashes = n.GetObjectValue<Meta_hashes>(Meta_hashes.CreateFromDiscriminatorValue); } },
                {"page", n => { Page = n.GetIntValue(); } },
                {"perPage", n => { PerPage = n.GetIntValue(); } },
                {"perTotal", n => { PerTotal = n.GetIntValue(); } },
                {"refreshAt", n => { RefreshAt = n.GetLongValue(); } },
                {"version", n => { Version = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("asOf", AsOf);
            writer.WriteObjectValue<Meta_hashes>("hashes", Hashes);
            writer.WriteIntValue("page", Page);
            writer.WriteIntValue("perPage", PerPage);
            writer.WriteIntValue("perTotal", PerTotal);
            writer.WriteLongValue("refreshAt", RefreshAt);
            writer.WriteIntValue("version", Version);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
