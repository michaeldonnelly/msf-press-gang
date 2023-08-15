using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Object mapping tier numbers (starting at 1) to NodeInfo objects.
    /// </summary>
    public class IndexedNodeInfos : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Information about a node. The `introStoryId` is played before character select at that node.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public NodeInfo? Pound { get; set; }
#nullable restore
#else
        public NodeInfo Pound { get; set; }
#endif
        /// <summary>
        /// Instantiates a new IndexedNodeInfos and sets the default values.
        /// </summary>
        public IndexedNodeInfos() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static IndexedNodeInfos CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new IndexedNodeInfos();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"#", n => { Pound = n.GetObjectValue<NodeInfo>(NodeInfo.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<NodeInfo>("#", Pound);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
