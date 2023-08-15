using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Represents progress towards a particular objective that may be ranked or have claimable tiers.
    /// </summary>
    public class Progress : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Tiers that have are currently claimable (and have not yet been claimed).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<int?>? ClaimableTiers { get; set; }
#nullable restore
#else
        public List<int?> ClaimableTiers { get; set; }
#endif
        /// <summary>The most recently completed tier.</summary>
        public int? CompletedTier { get; set; }
        /// <summary>For repeatable tiers, specifies the tier offset for the current completion run. This value should be added to all tier numbers for player-facing display.</summary>
        public int? CompletionOffset { get; set; }
        /// <summary>Starts at 1 for the player&apos;s first completion of the tiers. For repeatable tiers, goes up by 1 after each successful completion until reaching the Objective&apos;s `maxCompletions`.</summary>
        public int? CompletionRun { get; set; }
        /// <summary>Points needed for the next tier.</summary>
        public int? Goal { get; set; }
        /// <summary>The tier being worked on (*i.e.* the next tier).</summary>
        public int? GoalTier { get; set; }
        /// <summary>Points accumulated towards the next tier.</summary>
        public int? Points { get; set; }
        /// <summary>This entity&apos;s rank among others working on the same objective.</summary>
        public int? Rank { get; set; }
        /// <summary>
        /// Instantiates a new Progress and sets the default values.
        /// </summary>
        public Progress() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static Progress CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Progress();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"claimableTiers", n => { ClaimableTiers = n.GetCollectionOfPrimitiveValues<int?>()?.ToList(); } },
                {"completedTier", n => { CompletedTier = n.GetIntValue(); } },
                {"completionOffset", n => { CompletionOffset = n.GetIntValue(); } },
                {"completionRun", n => { CompletionRun = n.GetIntValue(); } },
                {"goal", n => { Goal = n.GetIntValue(); } },
                {"goalTier", n => { GoalTier = n.GetIntValue(); } },
                {"points", n => { Points = n.GetIntValue(); } },
                {"rank", n => { Rank = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfPrimitiveValues<int?>("claimableTiers", ClaimableTiers);
            writer.WriteIntValue("completedTier", CompletedTier);
            writer.WriteIntValue("completionOffset", CompletionOffset);
            writer.WriteIntValue("completionRun", CompletionRun);
            writer.WriteIntValue("goal", Goal);
            writer.WriteIntValue("goalTier", GoalTier);
            writer.WriteIntValue("points", Points);
            writer.WriteIntValue("rank", Rank);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
