using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Object containing information about a recruit&apos;s ad. (Format will be changed in an upcoming release without notice.)
    /// </summary>
    public class RecruitAd : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The language code.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Lang { get; set; }
#nullable restore
#else
        public string Lang { get; set; }
#endif
        /// <summary>The players&apos; level.</summary>
        public int? Level { get; set; }
        /// <summary>The player&apos;s strongest team power.</summary>
        public int? Stp { get; set; }
        /// <summary>The player&apos;s total collection power.</summary>
        public int? Tcp { get; set; }
        /// <summary>The players&apos; preferred time zone.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Timezone { get; set; }
#nullable restore
#else
        public string Timezone { get; set; }
#endif
        /// <summary>
        /// Instantiates a new RecruitAd and sets the default values.
        /// </summary>
        public RecruitAd() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static RecruitAd CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new RecruitAd();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"lang", n => { Lang = n.GetStringValue(); } },
                {"level", n => { Level = n.GetIntValue(); } },
                {"stp", n => { Stp = n.GetIntValue(); } },
                {"tcp", n => { Tcp = n.GetIntValue(); } },
                {"timezone", n => { Timezone = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("lang", Lang);
            writer.WriteIntValue("level", Level);
            writer.WriteIntValue("stp", Stp);
            writer.WriteIntValue("tcp", Tcp);
            writer.WriteStringValue("timezone", Timezone);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
