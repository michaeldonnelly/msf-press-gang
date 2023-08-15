using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// For character that use an Item
    /// </summary>
    public class ItemCharacterInfo : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Information about a character.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public CharacterInfo? Character { get; set; }
#nullable restore
#else
        public CharacterInfo Character { get; set; }
#endif
        /// <summary>Object mapping tier numbers (starting at 1) to EquipInfo objects.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public IndexedEquipsInfos? Equips { get; set; }
#nullable restore
#else
        public IndexedEquipsInfos Equips { get; set; }
#endif
        /// <summary>
        /// Instantiates a new ItemCharacterInfo and sets the default values.
        /// </summary>
        public ItemCharacterInfo() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static ItemCharacterInfo CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ItemCharacterInfo();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"character", n => { Character = n.GetObjectValue<CharacterInfo>(CharacterInfo.CreateFromDiscriminatorValue); } },
                {"equips", n => { Equips = n.GetObjectValue<IndexedEquipsInfos>(IndexedEquipsInfos.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<CharacterInfo>("character", Character);
            writer.WriteObjectValue<IndexedEquipsInfos>("equips", Equips);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
