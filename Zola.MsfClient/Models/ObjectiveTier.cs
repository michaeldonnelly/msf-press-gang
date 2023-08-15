using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Describes a scoring tier applicable to an objective.
    /// </summary>
    public class ObjectiveTier : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The points or percentage progress needed to reach the tier.</summary>
        public int? Goal { get; set; }
        /// <summary>For raid rewards at a given scoring tier, indicates the rewards available to members based on their damage rank range.Range rewards are not additive and are granted solely based on whichever range applies for the final score.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<ObjectiveRange>? RaidRewards { get; set; }
#nullable restore
#else
        public List<ObjectiveRange> RaidRewards { get; set; }
#endif
        /// <summary>A quantity of items (used for rewards).Contains at most one of `item`, `oneOf`, `allOf`, or `chanceOf`.The meaning is as follows:- `item` indicates that particular item.- `oneOf` indicates a package containing a random weighted selection from among its children.- `allOf` indicates a package containing all of its children.- `chanceOf` indicates a package which has a chance of containing its child.If the ItemQuantity object contains none of those four, it represents an empty package.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ItemQuantity? Rewards { get; set; }
#nullable restore
#else
        public ItemQuantity Rewards { get; set; }
#endif
        /// <summary>
        /// Instantiates a new ObjectiveTier and sets the default values.
        /// </summary>
        public ObjectiveTier() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static ObjectiveTier CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ObjectiveTier();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"goal", n => { Goal = n.GetIntValue(); } },
                {"raidRewards", n => { RaidRewards = n.GetCollectionOfObjectValues<ObjectiveRange>(ObjectiveRange.CreateFromDiscriminatorValue)?.ToList(); } },
                {"rewards", n => { Rewards = n.GetObjectValue<ItemQuantity>(ItemQuantity.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("goal", Goal);
            writer.WriteCollectionOfObjectValues<ObjectiveRange>("raidRewards", RaidRewards);
            writer.WriteObjectValue<ItemQuantity>("rewards", Rewards);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
