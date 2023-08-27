using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Represents a combat wave.
    /// </summary>
    public class CombatWave : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Does not progress to the next combat wave until the condition is met.- `OwnDeadThisWave` Met if `holdNum` units from this combat wave are dead.- `AllOwnDeadThisWave` Met if all of the units from this combat wave are dead.- `AllOwnDeadThisCombat` Met if the side has no units remaining, from this or any other combat wave.- `AnyVipKilled` Met after any unit with the `vip` NodeEffect is killed.- `AllOwnVipKilled` Met after all units with the `vip` NodeEffect are killed on the side.- `AnyVipDoesBasic` Met after any unit with the `vip` NodeEffect performs their basic ability.- `AnyVipDoesSpecial` Met after any unit with the `vip` NodeEffect performs their special ability.- `AnyVipDoesUltimate` Met after any unit with the `vip` NodeEffect performs their ultimate ability.- `OwnActionsThisWave` Met after `holdNum` actions have been performed by units on the side since the combat wave was first triggered.- `OwnActionsThisCombat` Met after `holdNum` actions have been performed by units on the side since the start of combat.- `EnemyActionsThisCombat` Met after `holdNum` actions have been performed by units on the enemy side since the start of combat.</summary>
        public CombatWave_holdNextWaveUntil? HoldNextWaveUntil { get; set; }
        /// <summary>When relevant for the value of `holdNextWaveUntil`, specifies the relevant number to hold the next wave for.</summary>
        public int? HoldNum { get; set; }
        /// <summary>The maximum number of units to spawn each time this combat wave is triggered. If omitted, there is no maximum.</summary>
        public int? MaxSpawnPerTick { get; set; }
        /// <summary>When the number of units on the side drops below this number, trigger the wave. If omitted, the wave is triggered regardless of the number of units on the side.</summary>
        public int? OnFewerThan { get; set; }
        /// <summary>How much turn meter to give to units in this wave when they spawn, `1000` being a full turn. Defaults to `0`.</summary>
        public int? TurnMeter { get; set; }
        /// <summary>The units in this combat wave.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<WithCombat>? Units { get; set; }
#nullable restore
#else
        public List<WithCombat> Units { get; set; }
#endif
        /// <summary>A Story Id. Can be imperfectly mapped to `/localizations/dialog` using `ID_DIALOG_${storyId}_${index}` where index goes from `0` to however many lines there are in the story. The design for this information is incomplete.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? WaveStoryId { get; set; }
#nullable restore
#else
        public string WaveStoryId { get; set; }
#endif
        /// <summary>
        /// Instantiates a new CombatWave and sets the default values.
        /// </summary>
        public CombatWave() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static CombatWave CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CombatWave();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"holdNextWaveUntil", n => { HoldNextWaveUntil = n.GetEnumValue<CombatWave_holdNextWaveUntil>(); } },
                {"holdNum", n => { HoldNum = n.GetIntValue(); } },
                {"maxSpawnPerTick", n => { MaxSpawnPerTick = n.GetIntValue(); } },
                {"onFewerThan", n => { OnFewerThan = n.GetIntValue(); } },
                {"turnMeter", n => { TurnMeter = n.GetIntValue(); } },
                {"units", n => { Units = n.GetCollectionOfObjectValues<WithCombat>(WithCombat.CreateFromDiscriminatorValue)?.ToList(); } },
                {"waveStoryId", n => { WaveStoryId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteEnumValue<CombatWave_holdNextWaveUntil>("holdNextWaveUntil", HoldNextWaveUntil);
            writer.WriteIntValue("holdNum", HoldNum);
            writer.WriteIntValue("maxSpawnPerTick", MaxSpawnPerTick);
            writer.WriteIntValue("onFewerThan", OnFewerThan);
            writer.WriteIntValue("turnMeter", TurnMeter);
            writer.WriteCollectionOfObjectValues<WithCombat>("units", Units);
            writer.WriteStringValue("waveStoryId", WaveStoryId);
            writer.WriteAdditionalData(AdditionalData);
        }
        /// <summary>
        /// Composed type wrapper for classes CharacterInstance, CharacterInstance
        /// </summary>
        public class WithCombat : IAdditionalDataHolder, IParsable {
            /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
            public IDictionary<string, object> AdditionalData { get; set; }
            /// <summary>Composed type representation for type CharacterInstance</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public Zola.MsfClient.Models.CharacterInstance? CharacterInstance { get; set; }
#nullable restore
#else
            public Zola.MsfClient.Models.CharacterInstance CharacterInstance { get; set; }
#endif
            /// <summary>Serialization hint for the current wrapper.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? SerializationHint { get; set; }
#nullable restore
#else
            public string SerializationHint { get; set; }
#endif
            /// <summary>
            /// Instantiates a new WithCombat and sets the default values.
            /// </summary>
            public WithCombat() {
                AdditionalData = new Dictionary<string, object>();
            }
            /// <summary>
            /// Creates a new instance of the appropriate class based on discriminator value
            /// </summary>
            /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
            public static WithCombat CreateFromDiscriminatorValue(IParseNode parseNode) {
                _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
                var mappingValue = parseNode.GetChildNode("")?.GetStringValue();
                var result = new WithCombat();
                if("CharacterInstance".Equals(mappingValue, StringComparison.OrdinalIgnoreCase)) {
                    result.CharacterInstance = new Zola.MsfClient.Models.CharacterInstance();
                }
                return result;
            }
            /// <summary>
            /// The deserialization information for the current model
            /// </summary>
            public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
                if(CharacterInstance != null) {
                    return CharacterInstance.GetFieldDeserializers();
                }
                return new Dictionary<string, Action<IParseNode>>();
            }
            /// <summary>
            /// Serializes information the current object
            /// </summary>
            /// <param name="writer">Serialization writer to use to serialize this model</param>
            public void Serialize(ISerializationWriter writer) {
                _ = writer ?? throw new ArgumentNullException(nameof(writer));
                if(CharacterInstance != null) {
                    writer.WriteObjectValue<Zola.MsfClient.Models.CharacterInstance>(null, CharacterInstance);
                }
                writer.WriteAdditionalData(AdditionalData);
            }
        }
    }
}
