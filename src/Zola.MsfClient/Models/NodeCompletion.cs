using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Represents a degree of completion of a node.
    /// </summary>
    public class NodeCompletion : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>For episodic types, the `chapterId` of the chapter in the episodic containing the node.</summary>
        public int? Chapter { get; set; }
        /// <summary>The number of stars of completion.</summary>
        public int? CompletionStars { get; set; }
        /// <summary>For episodic types, the `episodicId` of the episodic containing the node.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Id { get; set; }
#nullable restore
#else
        public string Id { get; set; }
#endif
        /// <summary>For episodic types, the `tierId` of the node within the chapter of the episodic.</summary>
        public int? Tier { get; set; }
        /// <summary>The type of node.- `campaign` A campaign node.- `eventCampaign` An event campaign node.- `challenge` A challenge node.- `other` Another kind of node.</summary>
        public NodeCompletion_type? Type { get; set; }
        /// <summary>
        /// Instantiates a new NodeCompletion and sets the default values.
        /// </summary>
        public NodeCompletion() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static NodeCompletion CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new NodeCompletion();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"chapter", n => { Chapter = n.GetIntValue(); } },
                {"completionStars", n => { CompletionStars = n.GetIntValue(); } },
                {"id", n => { Id = n.GetStringValue(); } },
                {"tier", n => { Tier = n.GetIntValue(); } },
                {"type", n => { Type = n.GetEnumValue<NodeCompletion_type>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("chapter", Chapter);
            writer.WriteIntValue("completionStars", CompletionStars);
            writer.WriteStringValue("id", Id);
            writer.WriteIntValue("tier", Tier);
            writer.WriteEnumValue<NodeCompletion_type>("type", Type);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
