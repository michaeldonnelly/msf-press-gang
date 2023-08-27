using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Represents non-character requirements.
    /// </summary>
    public class OtherRequirements : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Must have completed all the specified nodes to the specified degree of completion.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<NodeCompletion>? AllNodeCompletions { get; set; }
#nullable restore
#else
        public List<NodeCompletion> AllNodeCompletions { get; set; }
#endif
        /// <summary>Must be one of the specified days of the week. Days of the week are represented `0` (Sunday) through `6` (Saturday).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<int?>? AnyDaysOfWeek { get; set; }
#nullable restore
#else
        public List<int?> AnyDaysOfWeek { get; set; }
#endif
        /// <summary>Minimum player level.</summary>
        public int? PlayerLevel { get; set; }
        /// <summary>
        /// Instantiates a new OtherRequirements and sets the default values.
        /// </summary>
        public OtherRequirements() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static OtherRequirements CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OtherRequirements();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"allNodeCompletions", n => { AllNodeCompletions = n.GetCollectionOfObjectValues<NodeCompletion>(NodeCompletion.CreateFromDiscriminatorValue)?.ToList(); } },
                {"anyDaysOfWeek", n => { AnyDaysOfWeek = n.GetCollectionOfPrimitiveValues<int?>()?.ToList(); } },
                {"playerLevel", n => { PlayerLevel = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<NodeCompletion>("allNodeCompletions", AllNodeCompletions);
            writer.WriteCollectionOfPrimitiveValues<int?>("anyDaysOfWeek", AnyDaysOfWeek);
            writer.WriteIntValue("playerLevel", PlayerLevel);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
