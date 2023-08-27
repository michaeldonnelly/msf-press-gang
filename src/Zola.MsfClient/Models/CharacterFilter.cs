using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Represents requirements on an instance of a character. The character instance must satisfy each of the contained requirements to match this filter.
    /// </summary>
    public class CharacterFilter : IAdditionalDataHolder, IParsable {
        /// <summary>Minimum number of active yellow stars.</summary>
        public int? ActiveYellow { get; set; }
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The character instance must have each of these traits.</summary>
        public List<string>? AllTraits { get; set; }
        /// <summary>The character instance must be one of these characters.</summary>
        public List<string>? AnyCharacters { get; set; }
        /// <summary>The character instance must have at least one of these traits.</summary>
        public List<string>? AnyTraits { get; set; }
        /// <summary>The character instance must *not* have any of these traits.</summary>
        public List<string>? ExceptTraits { get; set; }
        /// <summary>Minimum gear tier.</summary>
        public int? GearTier { get; set; }
        /// <summary>Required ISO-8 class.</summary>
        public CharacterFilter_iso8Class? Iso8Class { get; set; }
        /// <summary>Minimum level required of equipped ISO-8 class.</summary>
        public int? Iso8ClassLevel { get; set; }
        /// <summary>Minimum character level.</summary>
        public int? Level { get; set; }
        /// <summary>
        /// Instantiates a new CharacterFilter and sets the default values.
        /// </summary>
        public CharacterFilter() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static CharacterFilter CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CharacterFilter();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"activeYellow", n => { ActiveYellow = n.GetIntValue(); } },
                {"allTraits", n => { AllTraits = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"anyCharacters", n => { AnyCharacters = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"anyTraits", n => { AnyTraits = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"exceptTraits", n => { ExceptTraits = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"gearTier", n => { GearTier = n.GetIntValue(); } },
                {"iso8Class", n => { Iso8Class = n.GetEnumValue<CharacterFilter_iso8Class>(); } },
                {"iso8ClassLevel", n => { Iso8ClassLevel = n.GetIntValue(); } },
                {"level", n => { Level = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("activeYellow", ActiveYellow);
            writer.WriteCollectionOfPrimitiveValues<string>("allTraits", AllTraits);
            writer.WriteCollectionOfPrimitiveValues<string>("anyCharacters", AnyCharacters);
            writer.WriteCollectionOfPrimitiveValues<string>("anyTraits", AnyTraits);
            writer.WriteCollectionOfPrimitiveValues<string>("exceptTraits", ExceptTraits);
            writer.WriteIntValue("gearTier", GearTier);
            writer.WriteEnumValue<CharacterFilter_iso8Class>("iso8Class", Iso8Class);
            writer.WriteIntValue("iso8ClassLevel", Iso8ClassLevel);
            writer.WriteIntValue("level", Level);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
