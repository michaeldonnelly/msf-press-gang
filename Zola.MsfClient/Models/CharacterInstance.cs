using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// An instance of a character (for example, a particular character in a roster, a particular enemy on a raid node, etc.).
    /// </summary>
    public class CharacterInstance : IAdditionalDataHolder, IParsable {
        /// <summary>Active red stars. Does not include red stars beyond active yellow stars. Omitted for locked characters.</summary>
        public int? ActiveRed { get; set; }
        /// <summary>Active yellow stars. Omitted for locked characters.</summary>
        public int? ActiveYellow { get; set; }
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Basic ability level. Omitted for locked characters.</summary>
        public int? Basic { get; set; }
        /// <summary>Costume number of equipped costume. Omitted if no costume is equipped.</summary>
        public int? Costume { get; set; }
        /// <summary>A boost to stats.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public StatBoost? DifficultyBoost { get; set; }
#nullable restore
#else
        public StatBoost DifficultyBoost { get; set; }
#endif
        /// <summary>Wehther the character is marked as VS Battle favorite by the player</summary>
        public bool? DraftFavorite { get; set; }
        /// <summary>Whether the character is marked as favorite by the player</summary>
        public bool? Favorite { get; set; }
        /// <summary>Gear slots (equipped = true), top to bottom on the left, then the right. Omitted for locked characters.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<bool?>? GearSlots { get; set; }
#nullable restore
#else
        public List<bool?> GearSlots { get; set; }
#endif
        /// <summary>Gear tier. Omitted for locked characters.</summary>
        public int? GearTier { get; set; }
        /// <summary>The id property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Id { get; set; }
#nullable restore
#else
        public string Id { get; set; }
#endif
        /// <summary>Information about a character.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public CharacterInfo? Info { get; set; }
#nullable restore
#else
        public CharacterInfo Info { get; set; }
#endif
        /// <summary>Represents the ISO-8 of a character.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Zola.MsfClient.Models.Iso8? Iso8 { get; set; }
#nullable restore
#else
        public Zola.MsfClient.Models.Iso8 Iso8 { get; set; }
#endif
        /// <summary>Character level. Omitted for locked characters.</summary>
        public int? Level { get; set; }
        /// <summary>True if this information is about the mission variant of a character. Note that neither ability kits nor gear slots are available for mission variants, nor can they generally be assumed to be the same as the player variants of a character.</summary>
        public bool? Mission { get; set; }
        /// <summary>Describes effects on a character specific to a particular node. Any omitted value means that effect is not applied.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Zola.MsfClient.Models.NodeEffects? NodeEffects { get; set; }
#nullable restore
#else
        public Zola.MsfClient.Models.NodeEffects NodeEffects { get; set; }
#endif
        /// <summary>Passive ability level.</summary>
        public int? Passive { get; set; }
        /// <summary>The character&apos;s power or approximate power. Omitted for locked characters.</summary>
        public int? Power { get; set; }
        /// <summary>The character&apos;s stats as seen on the character sheet (including select passive abilities). Only available for non-mission characters.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Zola.MsfClient.Models.Stats? SheetStats { get; set; }
#nullable restore
#else
        public Zola.MsfClient.Models.Stats SheetStats { get; set; }
#endif
        /// <summary>Special ability level.</summary>
        public int? Special { get; set; }
        /// <summary>A boost to stats.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public StatBoost? StarkBoost { get; set; }
#nullable restore
#else
        public StatBoost StarkBoost { get; set; }
#endif
        /// <summary>The character&apos;s base stats for combat purposes (**after** applying all equipped gears, stars, ISO-8, stark tech, and war/difficulty/node effects but **before** applying any passive abilities or combat buffs or debuffs).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Zola.MsfClient.Models.Stats? Stats { get; set; }
#nullable restore
#else
        public Zola.MsfClient.Models.Stats Stats { get; set; }
#endif
        /// <summary>Ultimate ability level.</summary>
        public int? Ultimate { get; set; }
        /// <summary>A war context used for calculating boosts. (Default: no war boosts.)Format:  `{attack or defend};{own helicarrier};{enemy helicarrier};{battle room}` (irrelevant trailing segments may be omitted)Helicarriers:  12 room codes (from the list below) for the layout of the helicarrier, left-to-right, then top-to-bottom. (If fewer than 12 room codes are provided, it is padded at the end with defeated rooms.)  - `A` Armory  - `B` Barracks  - `C` Cargo Bay  - `E` Engineering  - `G` bridGe  - `H` Hangar  - `M` Med Bay  - `R` Reactor  - `S` Security  - `X` Flight Deck 1  - `Y` Flight Deck 2  - `Z` Flight Deck 3  - `-` Defeated RoomBattle Room:  The number from `1` to `12` (numbered left-to-right, then top-to-bottom) of the room in which the battle is taking place. For attacks, the room is in the enemy&apos;s helicarrier. For defends, the room is in the character&apos;s own helicarrier.Example:  `attack:X-ZSRMHGEABC:XYZREGHSCBMA:5` represents an attack on the enemy&apos;s Engineering room, after the character&apos;s own Flight Deck 2 has been defeated.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? War { get; set; }
#nullable restore
#else
        public string War { get; set; }
#endif
        /// <summary>
        /// Instantiates a new CharacterInstance and sets the default values.
        /// </summary>
        public CharacterInstance() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static CharacterInstance CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CharacterInstance();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"activeRed", n => { ActiveRed = n.GetIntValue(); } },
                {"activeYellow", n => { ActiveYellow = n.GetIntValue(); } },
                {"basic", n => { Basic = n.GetIntValue(); } },
                {"costume", n => { Costume = n.GetIntValue(); } },
                {"difficultyBoost", n => { DifficultyBoost = n.GetObjectValue<StatBoost>(StatBoost.CreateFromDiscriminatorValue); } },
                {"draftFavorite", n => { DraftFavorite = n.GetBoolValue(); } },
                {"favorite", n => { Favorite = n.GetBoolValue(); } },
                {"gearSlots", n => { GearSlots = n.GetCollectionOfPrimitiveValues<bool?>()?.ToList(); } },
                {"gearTier", n => { GearTier = n.GetIntValue(); } },
                {"id", n => { Id = n.GetStringValue(); } },
                {"info", n => { Info = n.GetObjectValue<CharacterInfo>(CharacterInfo.CreateFromDiscriminatorValue); } },
                {"iso8", n => { Iso8 = n.GetObjectValue<Zola.MsfClient.Models.Iso8>(Zola.MsfClient.Models.Iso8.CreateFromDiscriminatorValue); } },
                {"level", n => { Level = n.GetIntValue(); } },
                {"mission", n => { Mission = n.GetBoolValue(); } },
                {"nodeEffects", n => { NodeEffects = n.GetObjectValue<Zola.MsfClient.Models.NodeEffects>(Zola.MsfClient.Models.NodeEffects.CreateFromDiscriminatorValue); } },
                {"passive", n => { Passive = n.GetIntValue(); } },
                {"power", n => { Power = n.GetIntValue(); } },
                {"sheetStats", n => { SheetStats = n.GetObjectValue<Stats>(Zola.MsfClient.Models.Stats.CreateFromDiscriminatorValue); } },
                {"special", n => { Special = n.GetIntValue(); } },
                {"starkBoost", n => { StarkBoost = n.GetObjectValue<StatBoost>(StatBoost.CreateFromDiscriminatorValue); } },
                {"stats", n => { Stats = n.GetObjectValue<Stats>(Stats.CreateFromDiscriminatorValue); } },
                {"ultimate", n => { Ultimate = n.GetIntValue(); } },
                {"war", n => { War = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("activeRed", ActiveRed);
            writer.WriteIntValue("activeYellow", ActiveYellow);
            writer.WriteIntValue("basic", Basic);
            writer.WriteIntValue("costume", Costume);
            writer.WriteObjectValue<StatBoost>("difficultyBoost", DifficultyBoost);
            writer.WriteBoolValue("draftFavorite", DraftFavorite);
            writer.WriteBoolValue("favorite", Favorite);
            writer.WriteCollectionOfPrimitiveValues<bool?>("gearSlots", GearSlots);
            writer.WriteIntValue("gearTier", GearTier);
            writer.WriteStringValue("id", Id);
            writer.WriteObjectValue<CharacterInfo>("info", Info);
            writer.WriteObjectValue<Zola.MsfClient.Models.Iso8>("iso8", Iso8);
            writer.WriteIntValue("level", Level);
            writer.WriteBoolValue("mission", Mission);
            writer.WriteObjectValue<Zola.MsfClient.Models.NodeEffects>("nodeEffects", NodeEffects);
            writer.WriteIntValue("passive", Passive);
            writer.WriteIntValue("power", Power);
            writer.WriteObjectValue<Zola.MsfClient.Models.Stats>("sheetStats", SheetStats);
            writer.WriteIntValue("special", Special);
            writer.WriteObjectValue<StatBoost>("starkBoost", StarkBoost);
            writer.WriteObjectValue<Zola.MsfClient.Models.Stats>("stats", Stats);
            writer.WriteIntValue("ultimate", Ultimate);
            writer.WriteStringValue("war", War);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
