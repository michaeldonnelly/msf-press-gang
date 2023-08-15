using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Milestone information for an event. (For `milestone` type only.)
    /// </summary>
    public class MilestoneEventInfo : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The brackets property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Bracket>? Brackets { get; set; }
#nullable restore
#else
        public List<Bracket> Brackets { get; set; }
#endif
        /// <summary>Describes how the milestone is scored.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public MilestoneEventInfo_scoring? Scoring { get; set; }
#nullable restore
#else
        public MilestoneEventInfo_scoring Scoring { get; set; }
#endif
        /// <summary>The functional type of the milestone event.</summary>
        public MilestoneEventInfo_type? Type { get; set; }
        /// <summary>(localized)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? TypeName { get; set; }
#nullable restore
#else
        public string TypeName { get; set; }
#endif
        /// <summary>
        /// Instantiates a new MilestoneEventInfo and sets the default values.
        /// </summary>
        public MilestoneEventInfo() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static MilestoneEventInfo CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new MilestoneEventInfo();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"brackets", n => { Brackets = n.GetCollectionOfObjectValues<Bracket>(Bracket.CreateFromDiscriminatorValue)?.ToList(); } },
                {"scoring", n => { Scoring = n.GetObjectValue<MilestoneEventInfo_scoring>(MilestoneEventInfo_scoring.CreateFromDiscriminatorValue); } },
                {"type", n => { Type = n.GetEnumValue<MilestoneEventInfo_type>(); } },
                {"typeName", n => { TypeName = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<Bracket>("brackets", Brackets);
            writer.WriteObjectValue<MilestoneEventInfo_scoring>("scoring", Scoring);
            writer.WriteEnumValue<MilestoneEventInfo_type>("type", Type);
            writer.WriteStringValue("typeName", TypeName);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
