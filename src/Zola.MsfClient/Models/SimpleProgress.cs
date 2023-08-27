using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Represents simple progress towards a particular objective.
    /// </summary>
    public class SimpleProgress : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The most recently completed tier.</summary>
        public int? CompletedTier { get; set; }
        /// <summary>Points needed for the next tier.</summary>
        public int? Goal { get; set; }
        /// <summary>The tier being worked on (*i.e.* the next tier).</summary>
        public int? GoalTier { get; set; }
        /// <summary>Points accumulated towards the next tier.</summary>
        public int? Points { get; set; }
        /// <summary>
        /// Instantiates a new SimpleProgress and sets the default values.
        /// </summary>
        public SimpleProgress() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static SimpleProgress CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SimpleProgress();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"completedTier", n => { CompletedTier = n.GetIntValue(); } },
                {"goal", n => { Goal = n.GetIntValue(); } },
                {"goalTier", n => { GoalTier = n.GetIntValue(); } },
                {"points", n => { Points = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("completedTier", CompletedTier);
            writer.WriteIntValue("goal", Goal);
            writer.WriteIntValue("goalTier", GoalTier);
            writer.WriteIntValue("points", Points);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
