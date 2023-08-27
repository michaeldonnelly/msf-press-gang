using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    public class MilestoneEventInfo_scoring_cappedScorings : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The maximum combined points that can be earned by these scoring methods.</summary>
        public int? Cap { get; set; }
        /// <summary>An array of capped methods for scoring points for this milestone.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<ScoringMethod>? Methods { get; set; }
#nullable restore
#else
        public List<ScoringMethod> Methods { get; set; }
#endif
        /// <summary>How many combined points the player has earned from these scoring methods so far.</summary>
        public int? SoFar { get; set; }
        /// <summary>
        /// Instantiates a new MilestoneEventInfo_scoring_cappedScorings and sets the default values.
        /// </summary>
        public MilestoneEventInfo_scoring_cappedScorings() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static MilestoneEventInfo_scoring_cappedScorings CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new MilestoneEventInfo_scoring_cappedScorings();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"cap", n => { Cap = n.GetIntValue(); } },
                {"methods", n => { Methods = n.GetCollectionOfObjectValues<ScoringMethod>(ScoringMethod.CreateFromDiscriminatorValue)?.ToList(); } },
                {"soFar", n => { SoFar = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("cap", Cap);
            writer.WriteCollectionOfObjectValues<ScoringMethod>("methods", Methods);
            writer.WriteIntValue("soFar", SoFar);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
