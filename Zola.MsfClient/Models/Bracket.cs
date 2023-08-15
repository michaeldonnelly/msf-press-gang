using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Information about a scoring bracket for a subset of players.
    /// </summary>
    public class Bracket : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>An identifier for the bracket.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Id { get; set; }
#nullable restore
#else
        public string Id { get; set; }
#endif
        /// <summary>Describes an objective including its scoring tiers or ranges.The `progress` field is only present when requesting a player&apos;s progress toward the objective. For raids, the `progress` field represents the alliance&apos;s progress on the raid and the `contribution` field represents the player&apos;s damage contribution.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Zola.MsfClient.Models.Objective? Objective { get; set; }
#nullable restore
#else
        public Zola.MsfClient.Models.Objective Objective { get; set; }
#endif
        /// <summary>
        /// Instantiates a new Bracket and sets the default values.
        /// </summary>
        public Bracket() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static Bracket CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Bracket();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"id", n => { Id = n.GetStringValue(); } },
                {"objective", n => { Objective = n.GetObjectValue<Zola.MsfClient.Models.Objective>(Zola.MsfClient.Models.Objective.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("id", Id);
            writer.WriteObjectValue<Zola.MsfClient.Models.Objective>("objective", Objective);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
