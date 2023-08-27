using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Describes effects on a character specific to a particular node. Any omitted value means that effect is not applied.
    /// </summary>
    public class NodeEffects : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>True if players cannot control this character, even when it&apos;s on their own side.</summary>
        public bool? AutoPlay { get; set; }
        /// <summary>A boost to stats.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public StatBoost? Boosts { get; set; }
#nullable restore
#else
        public StatBoost Boosts { get; set; }
#endif
        /// <summary>The currentHealthPercent property</summary>
        public int? CurrentHealthPercent { get; set; }
        /// <summary>Energy settings for an ability.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public AbilityEnergy? EmpoweredSpecialOverride { get; set; }
#nullable restore
#else
        public AbilityEnergy EmpoweredSpecialOverride { get; set; }
#endif
        /// <summary>Energy settings for an ability.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public AbilityEnergy? EmpoweredUltimateOverride { get; set; }
#nullable restore
#else
        public AbilityEnergy EmpoweredUltimateOverride { get; set; }
#endif
        /// <summary>Additional fractional gear tier from node effects.</summary>
        public int? GearPercent { get; set; }
        /// <summary>Energy settings for an ability.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public AbilityEnergy? SpecialOverride { get; set; }
#nullable restore
#else
        public AbilityEnergy SpecialOverride { get; set; }
#endif
        /// <summary>True if this character is marked as a target.</summary>
        public bool? Target { get; set; }
        /// <summary>Energy settings for an ability.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public AbilityEnergy? UltimateOverride { get; set; }
#nullable restore
#else
        public AbilityEnergy UltimateOverride { get; set; }
#endif
        /// <summary>True if this character is considered a VIP for controlling combat waves.</summary>
        public bool? Vip { get; set; }
        /// <summary>The character&apos;s preferred x position on the battlefield, 0 being their own far left, 4 being their own far right.</summary>
        public int? X { get; set; }
        /// <summary>The character&apos;s preferred y position on the battlefield, 0 being the back row, 1 being the front row.</summary>
        public int? Y { get; set; }
        /// <summary>
        /// Instantiates a new NodeEffects and sets the default values.
        /// </summary>
        public NodeEffects() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static NodeEffects CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new NodeEffects();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"autoPlay", n => { AutoPlay = n.GetBoolValue(); } },
                {"boosts", n => { Boosts = n.GetObjectValue<StatBoost>(StatBoost.CreateFromDiscriminatorValue); } },
                {"currentHealthPercent", n => { CurrentHealthPercent = n.GetIntValue(); } },
                {"empoweredSpecialOverride", n => { EmpoweredSpecialOverride = n.GetObjectValue<AbilityEnergy>(AbilityEnergy.CreateFromDiscriminatorValue); } },
                {"empoweredUltimateOverride", n => { EmpoweredUltimateOverride = n.GetObjectValue<AbilityEnergy>(AbilityEnergy.CreateFromDiscriminatorValue); } },
                {"gearPercent", n => { GearPercent = n.GetIntValue(); } },
                {"specialOverride", n => { SpecialOverride = n.GetObjectValue<AbilityEnergy>(AbilityEnergy.CreateFromDiscriminatorValue); } },
                {"target", n => { Target = n.GetBoolValue(); } },
                {"ultimateOverride", n => { UltimateOverride = n.GetObjectValue<AbilityEnergy>(AbilityEnergy.CreateFromDiscriminatorValue); } },
                {"vip", n => { Vip = n.GetBoolValue(); } },
                {"x", n => { X = n.GetIntValue(); } },
                {"y", n => { Y = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("autoPlay", AutoPlay);
            writer.WriteObjectValue<StatBoost>("boosts", Boosts);
            writer.WriteIntValue("currentHealthPercent", CurrentHealthPercent);
            writer.WriteObjectValue<AbilityEnergy>("empoweredSpecialOverride", EmpoweredSpecialOverride);
            writer.WriteObjectValue<AbilityEnergy>("empoweredUltimateOverride", EmpoweredUltimateOverride);
            writer.WriteIntValue("gearPercent", GearPercent);
            writer.WriteObjectValue<AbilityEnergy>("specialOverride", SpecialOverride);
            writer.WriteBoolValue("target", Target);
            writer.WriteObjectValue<AbilityEnergy>("ultimateOverride", UltimateOverride);
            writer.WriteBoolValue("vip", Vip);
            writer.WriteIntValue("x", X);
            writer.WriteIntValue("y", Y);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
