using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Achieved if the timer expires.
    /// </summary>
    public class CombatObjectives_timer : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>A Story Id. Can be imperfectly mapped to `/localizations/dialog` using `ID_DIALOG_${storyId}_${index}` where index goes from `0` to however many lines there are in the story. The design for this information is incomplete.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? EndStoryId { get; set; }
#nullable restore
#else
        public string EndStoryId { get; set; }
#endif
        /// <summary>The minutes property</summary>
        public int? Minutes { get; set; }
        /// <summary>The seconds property</summary>
        public int? Seconds { get; set; }
        /// <summary>
        /// Instantiates a new CombatObjectives_timer and sets the default values.
        /// </summary>
        public CombatObjectives_timer() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static CombatObjectives_timer CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CombatObjectives_timer();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"endStoryId", n => { EndStoryId = n.GetStringValue(); } },
                {"minutes", n => { Minutes = n.GetIntValue(); } },
                {"seconds", n => { Seconds = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("endStoryId", EndStoryId);
            writer.WriteIntValue("minutes", Minutes);
            writer.WriteIntValue("seconds", Seconds);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
