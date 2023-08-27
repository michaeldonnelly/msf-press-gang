using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Tower information for an event. (For `tower` type only.)
    /// </summary>
    public class TowerEventInfo : IAdditionalDataHolder, IParsable {
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
        /// <summary>Represents requirements.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Zola.MsfClient.Models.Requirements? Requirements { get; set; }
#nullable restore
#else
        public Zola.MsfClient.Models.Requirements Requirements { get; set; }
#endif
        /// <summary>
        /// Instantiates a new TowerEventInfo and sets the default values.
        /// </summary>
        public TowerEventInfo() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static TowerEventInfo CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new TowerEventInfo();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"brackets", n => { Brackets = n.GetCollectionOfObjectValues<Bracket>(Bracket.CreateFromDiscriminatorValue)?.ToList(); } },
                {"requirements", n => { Requirements = n.GetObjectValue<Zola.MsfClient.Models.Requirements>(Zola.MsfClient.Models.Requirements.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<Bracket>("brackets", Brackets);
            writer.WriteObjectValue<Zola.MsfClient.Models.Requirements>("requirements", Requirements);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
