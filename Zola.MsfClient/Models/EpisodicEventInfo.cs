using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Episodic information for an event. (For `episodic` type only.)
    /// </summary>
    public class EpisodicEventInfo : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>If itemFormat=id, just the ID string. Otherwise, the full Item object.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Item? Energy { get; set; }
#nullable restore
#else
        public Item Energy { get; set; }
#endif
        /// <summary>The episodicId for use with `/game/v1/episodics/flashEvent/{id}` or `/game/v1/episodics/unlockEvent/{id}`.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Id { get; set; }
#nullable restore
#else
        public string Id { get; set; }
#endif
        /// <summary>The episodicIds for use with `/game/v1/episodics/eventCampaign/{id}`.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? Ids { get; set; }
#nullable restore
#else
        public List<string> Ids { get; set; }
#endif
        /// <summary>The functional type of the episodic event.</summary>
        public EpisodicEventInfo_type? Type { get; set; }
        /// <summary>(localized)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? TypeName { get; set; }
#nullable restore
#else
        public string TypeName { get; set; }
#endif
        /// <summary>
        /// Instantiates a new EpisodicEventInfo and sets the default values.
        /// </summary>
        public EpisodicEventInfo() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static EpisodicEventInfo CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new EpisodicEventInfo();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"energy", n => { Energy = n.GetObjectValue<Item>(Item.CreateFromDiscriminatorValue); } },
                {"id", n => { Id = n.GetStringValue(); } },
                {"ids", n => { Ids = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"type", n => { Type = n.GetEnumValue<EpisodicEventInfo_type>(); } },
                {"typeName", n => { TypeName = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<Item>("energy", Energy);
            writer.WriteStringValue("id", Id);
            writer.WriteCollectionOfPrimitiveValues<string>("ids", Ids);
            writer.WriteEnumValue<EpisodicEventInfo_type>("type", Type);
            writer.WriteStringValue("typeName", TypeName);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
