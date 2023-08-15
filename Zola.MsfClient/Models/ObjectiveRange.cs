using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Describes a range of scores applicable to an objective.
    /// </summary>
    public class ObjectiveRange : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>A quantity of items (used for rewards).Contains at most one of `item`, `oneOf`, `allOf`, or `chanceOf`.The meaning is as follows:- `item` indicates that particular item.- `oneOf` indicates a package containing a random weighted selection from among its children.- `allOf` indicates a package containing all of its children.- `chanceOf` indicates a package which has a chance of containing its child.If the ItemQuantity object contains none of those four, it represents an empty package.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ItemQuantity? Rewards { get; set; }
#nullable restore
#else
        public ItemQuantity Rewards { get; set; }
#endif
        /// <summary>The start of the range. (The first number in the examples above.)</summary>
        public int? Start { get; set; }
        /// <summary>The end of the range. (The second number in the examples above.)</summary>
        public int? Stop { get; set; }
        /// <summary>Indicates the type of range:- `rank` indicates an absolute rank range like &quot;Rank 21-50&quot;.- `top` indicates a percentage range like &quot;Top 1-2%&quot;.</summary>
        public ObjectiveRange_type? Type { get; set; }
        /// <summary>
        /// Instantiates a new ObjectiveRange and sets the default values.
        /// </summary>
        public ObjectiveRange() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static ObjectiveRange CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ObjectiveRange();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"rewards", n => { Rewards = n.GetObjectValue<ItemQuantity>(ItemQuantity.CreateFromDiscriminatorValue); } },
                {"start", n => { Start = n.GetIntValue(); } },
                {"stop", n => { Stop = n.GetIntValue(); } },
                {"type", n => { Type = n.GetEnumValue<ObjectiveRange_type>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<ItemQuantity>("rewards", Rewards);
            writer.WriteIntValue("start", Start);
            writer.WriteIntValue("stop", Stop);
            writer.WriteEnumValue<ObjectiveRange_type>("type", Type);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
