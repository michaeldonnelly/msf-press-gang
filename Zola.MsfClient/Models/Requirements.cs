using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Represents requirements.
    /// </summary>
    public class Requirements : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Different character instances can match different filters, but each character instance must satisfy *all* of the requirements in *at least one* of these filters.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<CharacterFilter>? AnyCharacterFilters { get; set; }
#nullable restore
#else
        public List<CharacterFilter> AnyCharacterFilters { get; set; }
#endif
        /// <summary>Maximum number of characters allowed.</summary>
        public int? MaxCharacters { get; set; }
        /// <summary>Minimum number of characters required.</summary>
        public int? MinCharacters { get; set; }
        /// <summary>If `true`, only mission characters are allowed.</summary>
        public bool? MissionCharacters { get; set; }
        /// <summary>Represents non-character requirements.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Zola.MsfClient.Models.OtherRequirements? OtherRequirements { get; set; }
#nullable restore
#else
        public Zola.MsfClient.Models.OtherRequirements OtherRequirements { get; set; }
#endif
        /// <summary>All of these characters are required.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? SpecificCharacters { get; set; }
#nullable restore
#else
        public List<string> SpecificCharacters { get; set; }
#endif
        /// <summary>
        /// Instantiates a new Requirements and sets the default values.
        /// </summary>
        public Requirements() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static Requirements CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Requirements();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"anyCharacterFilters", n => { AnyCharacterFilters = n.GetCollectionOfObjectValues<CharacterFilter>(CharacterFilter.CreateFromDiscriminatorValue)?.ToList(); } },
                {"maxCharacters", n => { MaxCharacters = n.GetIntValue(); } },
                {"minCharacters", n => { MinCharacters = n.GetIntValue(); } },
                {"missionCharacters", n => { MissionCharacters = n.GetBoolValue(); } },
                {"otherRequirements", n => { OtherRequirements = n.GetObjectValue<Zola.MsfClient.Models.OtherRequirements>(Zola.MsfClient.Models.OtherRequirements.CreateFromDiscriminatorValue); } },
                {"specificCharacters", n => { SpecificCharacters = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<CharacterFilter>("anyCharacterFilters", AnyCharacterFilters);
            writer.WriteIntValue("maxCharacters", MaxCharacters);
            writer.WriteIntValue("minCharacters", MinCharacters);
            writer.WriteBoolValue("missionCharacters", MissionCharacters);
            writer.WriteObjectValue<Zola.MsfClient.Models.OtherRequirements>("otherRequirements", OtherRequirements);
            writer.WriteCollectionOfPrimitiveValues<string>("specificCharacters", SpecificCharacters);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
