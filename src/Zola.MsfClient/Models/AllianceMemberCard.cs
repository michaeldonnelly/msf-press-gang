using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Information about an alliance member.
    /// </summary>
    public class AllianceMemberCard : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The number of characters the player has collected.</summary>
        public int? CharactersCollected { get; set; }
        /// <summary>A URL.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Frame { get; set; }
#nullable restore
#else
        public string Frame { get; set; }
#endif
        /// <summary>A URL.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Icon { get; set; }
#nullable restore
#else
        public string Icon { get; set; }
#endif
        /// <summary>Represents simple progress towards a particular objective.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public SimpleProgress? Level { get; set; }
#nullable restore
#else
        public SimpleProgress Level { get; set; }
#endif
        /// <summary>The player&apos;s commander name.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Name { get; set; }
#nullable restore
#else
        public string Name { get; set; }
#endif
        /// <summary>The player&apos;s strongest team power.</summary>
        public int? Stp { get; set; }
        /// <summary>The player&apos;s total collection power.</summary>
        public int? Tcp { get; set; }
        /// <summary>The number of times the player was war MVP.</summary>
        public int? WarMvp { get; set; }
        /// <summary>
        /// Instantiates a new AllianceMemberCard and sets the default values.
        /// </summary>
        public AllianceMemberCard() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static AllianceMemberCard CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AllianceMemberCard();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"charactersCollected", n => { CharactersCollected = n.GetIntValue(); } },
                {"frame", n => { Frame = n.GetStringValue(); } },
                {"icon", n => { Icon = n.GetStringValue(); } },
                {"level", n => { Level = n.GetObjectValue<SimpleProgress>(SimpleProgress.CreateFromDiscriminatorValue); } },
                {"name", n => { Name = n.GetStringValue(); } },
                {"stp", n => { Stp = n.GetIntValue(); } },
                {"tcp", n => { Tcp = n.GetIntValue(); } },
                {"warMvp", n => { WarMvp = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("charactersCollected", CharactersCollected);
            writer.WriteStringValue("frame", Frame);
            writer.WriteStringValue("icon", Icon);
            writer.WriteObjectValue<SimpleProgress>("level", Level);
            writer.WriteStringValue("name", Name);
            writer.WriteIntValue("stp", Stp);
            writer.WriteIntValue("tcp", Tcp);
            writer.WriteIntValue("warMvp", WarMvp);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
