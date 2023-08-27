using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// These hashes will change when the underlying **non-player** data returnable by the API changes.If the hash value pertinent to a response is cached with the response, finding a different value for that hash on a future response can be used to invalidate the previously cached response.For example, if a request for CITY characters returns a &quot;chars&quot; hash of &quot;6b4&quot; and a later request for an alpha raid node returns a &quot;chars&quot; hash of &quot;6b4&quot;, there is no need to refresh the list of CITY characters. However, if the later request for an alpha raid node returns a &quot;chars&quot; hash of &quot;1b8&quot;, then the list of CITY characters has potentially been updated.
    /// </summary>
    public class Meta_hashes : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Changes whenever anything changes.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? All { get; set; }
#nullable restore
#else
        public string All { get; set; }
#endif
        /// <summary>Changes whenever characters are updated or new characters are added. This includes gear, abilities, ISO-8, etc.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Chars { get; set; }
#nullable restore
#else
        public string Chars { get; set; }
#endif
        /// <summary>Changes whenever any drops (from nodes, orbs, or offers) change.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Drops { get; set; }
#nullable restore
#else
        public string Drops { get; set; }
#endif
        /// <summary>Changes whenever an event is updated or a new event starts or stops, including daily milestones.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Events { get; set; }
#nullable restore
#else
        public string Events { get; set; }
#endif
        /// <summary>Changes whenever localized strings are updated.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Locs { get; set; }
#nullable restore
#else
        public string Locs { get; set; }
#endif
        /// <summary>Changes whenever any nodes (raid, dark dimension, campaigns, legendary events, event campaigns, challenges, flash events, etc., etc.) change or become active or inactive.Note that some nodes (like Greek raids) may remain available via the API even when not available in game. In these cases, the data available via the API might not change, even though this value does.Note, also, that some nodes (like event campaigns) may be conditional on events running. In these cases, the data available via the API might change, even though this value does not.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Nodes { get; set; }
#nullable restore
#else
        public string Nodes { get; set; }
#endif
        /// <summary>Changes whenever anything not categorized above changes. Currently, this includes things like event art and war bonuses.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Other { get; set; }
#nullable restore
#else
        public string Other { get; set; }
#endif
        /// <summary>
        /// Instantiates a new Meta_hashes and sets the default values.
        /// </summary>
        public Meta_hashes() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static Meta_hashes CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Meta_hashes();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"all", n => { All = n.GetStringValue(); } },
                {"chars", n => { Chars = n.GetStringValue(); } },
                {"drops", n => { Drops = n.GetStringValue(); } },
                {"events", n => { Events = n.GetStringValue(); } },
                {"locs", n => { Locs = n.GetStringValue(); } },
                {"nodes", n => { Nodes = n.GetStringValue(); } },
                {"other", n => { Other = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("all", All);
            writer.WriteStringValue("chars", Chars);
            writer.WriteStringValue("drops", Drops);
            writer.WriteStringValue("events", Events);
            writer.WriteStringValue("locs", Locs);
            writer.WriteStringValue("nodes", Nodes);
            writer.WriteStringValue("other", Other);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
