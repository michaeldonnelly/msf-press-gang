// foo
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Information about a chapter.
    /// </summary>
    public class ChapterInfo : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The number of tiers in this chapter.</summary>
        public int? NumTiers { get; set; }
        /// <summary>Represents requirements.</summary>
        public Zola.MsfClient.Models.Requirements? Requirements { get; set; }
        /// <summary>Object mapping tier numbers (starting at 1) to NodeInfo objects.</summary>
        public IndexedNodeInfos? Tiers { get; set; }
        /// <summary>
        /// Instantiates a new ChapterInfo and sets the default values.
        /// </summary>
        public ChapterInfo() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static ChapterInfo CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ChapterInfo();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"numTiers", n => { NumTiers = n.GetIntValue(); } },
                {"requirements", n => { Requirements = n.GetObjectValue<Zola.MsfClient.Models.Requirements>(Zola.MsfClient.Models.Requirements.CreateFromDiscriminatorValue); } },
                {"tiers", n => { Tiers = n.GetObjectValue<IndexedNodeInfos>(IndexedNodeInfos.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("numTiers", NumTiers);
            writer.WriteObjectValue<Zola.MsfClient.Models.Requirements>("requirements", Requirements);
            writer.WriteObjectValue<IndexedNodeInfos>("tiers", Tiers);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
