using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using Zola.MsfClient.Models;
namespace Zola.MsfClient.Game.V1.Iso8Abilities {
    public class Iso8AbilitiesResponse_data : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Information about an ability.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Ability? Fortifier { get; set; }
#nullable restore
#else
        public Ability Fortifier { get; set; }
#endif
        /// <summary>Information about an ability.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Ability? Healer { get; set; }
#nullable restore
#else
        public Ability Healer { get; set; }
#endif
        /// <summary>Information about an ability.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Ability? Raider { get; set; }
#nullable restore
#else
        public Ability Raider { get; set; }
#endif
        /// <summary>Information about an ability.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Ability? Skirmisher { get; set; }
#nullable restore
#else
        public Ability Skirmisher { get; set; }
#endif
        /// <summary>Information about an ability.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Ability? Striker { get; set; }
#nullable restore
#else
        public Ability Striker { get; set; }
#endif
        /// <summary>
        /// Instantiates a new iso8AbilitiesResponse_data and sets the default values.
        /// </summary>
        public Iso8AbilitiesResponse_data() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static Iso8AbilitiesResponse_data CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Iso8AbilitiesResponse_data();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"fortifier", n => { Fortifier = n.GetObjectValue<Ability>(Ability.CreateFromDiscriminatorValue); } },
                {"healer", n => { Healer = n.GetObjectValue<Ability>(Ability.CreateFromDiscriminatorValue); } },
                {"raider", n => { Raider = n.GetObjectValue<Ability>(Ability.CreateFromDiscriminatorValue); } },
                {"skirmisher", n => { Skirmisher = n.GetObjectValue<Ability>(Ability.CreateFromDiscriminatorValue); } },
                {"striker", n => { Striker = n.GetObjectValue<Ability>(Ability.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<Ability>("fortifier", Fortifier);
            writer.WriteObjectValue<Ability>("healer", Healer);
            writer.WriteObjectValue<Ability>("raider", Raider);
            writer.WriteObjectValue<Ability>("skirmisher", Skirmisher);
            writer.WriteObjectValue<Ability>("striker", Striker);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
