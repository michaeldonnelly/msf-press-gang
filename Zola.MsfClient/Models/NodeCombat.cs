using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Describes combat that can occur at a particular node.
    /// </summary>
    public class NodeCombat : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Represents a side in combat.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public NodeCombatSide? Left { get; set; }
#nullable restore
#else
        public NodeCombatSide Left { get; set; }
#endif
        /// <summary>The design for this information is incomplete.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public NodeCombat_map? Map { get; set; }
#nullable restore
#else
        public NodeCombat_map Map { get; set; }
#endif
        /// <summary>Represents a side in combat.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public NodeCombatSide? Right { get; set; }
#nullable restore
#else
        public NodeCombatSide Right { get; set; }
#endif
        /// <summary>
        /// Instantiates a new NodeCombat and sets the default values.
        /// </summary>
        public NodeCombat() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static NodeCombat CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new NodeCombat();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"left", n => { Left = n.GetObjectValue<NodeCombatSide>(NodeCombatSide.CreateFromDiscriminatorValue); } },
                {"map", n => { Map = n.GetObjectValue<NodeCombat_map>(NodeCombat_map.CreateFromDiscriminatorValue); } },
                {"right", n => { Right = n.GetObjectValue<NodeCombatSide>(NodeCombatSide.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<NodeCombatSide>("left", Left);
            writer.WriteObjectValue<NodeCombat_map>("map", Map);
            writer.WriteObjectValue<NodeCombatSide>("right", Right);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
