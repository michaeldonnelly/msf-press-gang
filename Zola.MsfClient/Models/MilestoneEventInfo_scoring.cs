using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Describes how the milestone is scored.
    /// </summary>
    public class MilestoneEventInfo_scoring : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The cappedScorings property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<MilestoneEventInfo_scoring_cappedScorings>? CappedScorings { get; set; }
#nullable restore
#else
        public List<MilestoneEventInfo_scoring_cappedScorings> CappedScorings { get; set; }
#endif
        /// <summary>(localized) The overall scoring description.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Description { get; set; }
#nullable restore
#else
        public string Description { get; set; }
#endif
        /// <summary>An array of uncapped methods for scoring points for this milestone.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<ScoringMethod>? Methods { get; set; }
#nullable restore
#else
        public List<ScoringMethod> Methods { get; set; }
#endif
        /// <summary>
        /// Instantiates a new MilestoneEventInfo_scoring and sets the default values.
        /// </summary>
        public MilestoneEventInfo_scoring() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static MilestoneEventInfo_scoring CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new MilestoneEventInfo_scoring();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"cappedScorings", n => { CappedScorings = n.GetCollectionOfObjectValues<MilestoneEventInfo_scoring_cappedScorings>(MilestoneEventInfo_scoring_cappedScorings.CreateFromDiscriminatorValue)?.ToList(); } },
                {"description", n => { Description = n.GetStringValue(); } },
                {"methods", n => { Methods = n.GetCollectionOfObjectValues<ScoringMethod>(ScoringMethod.CreateFromDiscriminatorValue)?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<MilestoneEventInfo_scoring_cappedScorings>("cappedScorings", CappedScorings);
            writer.WriteStringValue("description", Description);
            writer.WriteCollectionOfObjectValues<ScoringMethod>("methods", Methods);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
