using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Information about a player.
    /// </summary>
    public class PlayerCard : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The player&apos;s all-time arena rank.</summary>
        public int? BestArena { get; set; }
        /// <summary>The player&apos;s total number of blitz wins.</summary>
        public int? BlitzWins { get; set; }
        /// <summary>The number of characters the player has at max star rank.</summary>
        public int? CharactersAtMaxStarRank { get; set; }
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
        /// <summary>The player&apos;s latest arena rank.</summary>
        public int? LatestArena { get; set; }
        /// <summary>The player&apos;s latest blitz rank.</summary>
        public int? LatestBlitz { get; set; }
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
        /// Instantiates a new PlayerCard and sets the default values.
        /// </summary>
        public PlayerCard() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static PlayerCard CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new PlayerCard();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"bestArena", n => { BestArena = n.GetIntValue(); } },
                {"blitzWins", n => { BlitzWins = n.GetIntValue(); } },
                {"charactersAtMaxStarRank", n => { CharactersAtMaxStarRank = n.GetIntValue(); } },
                {"charactersCollected", n => { CharactersCollected = n.GetIntValue(); } },
                {"frame", n => { Frame = n.GetStringValue(); } },
                {"icon", n => { Icon = n.GetStringValue(); } },
                {"latestArena", n => { LatestArena = n.GetIntValue(); } },
                {"latestBlitz", n => { LatestBlitz = n.GetIntValue(); } },
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
            writer.WriteIntValue("bestArena", BestArena);
            writer.WriteIntValue("blitzWins", BlitzWins);
            writer.WriteIntValue("charactersAtMaxStarRank", CharactersAtMaxStarRank);
            writer.WriteIntValue("charactersCollected", CharactersCollected);
            writer.WriteStringValue("frame", Frame);
            writer.WriteStringValue("icon", Icon);
            writer.WriteIntValue("latestArena", LatestArena);
            writer.WriteIntValue("latestBlitz", LatestBlitz);
            writer.WriteObjectValue<SimpleProgress>("level", Level);
            writer.WriteStringValue("name", Name);
            writer.WriteIntValue("stp", Stp);
            writer.WriteIntValue("tcp", Tcp);
            writer.WriteIntValue("warMvp", WarMvp);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
