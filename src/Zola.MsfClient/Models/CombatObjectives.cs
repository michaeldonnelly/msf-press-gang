using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Describes a side&apos;s combat objectives. Achieving any one of the objectives is considered victory for that side. If the CombatObjectives object is omitted, victory is achieved if all enemies are dead. Otherwise, depending on which objective is achieved, the corresponding `endStoryId` is triggered.
    /// </summary>
    public class CombatObjectives : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Achieved if all enemies are dead.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public CombatObjectives_killAll? KillAll { get; set; }
#nullable restore
#else
        public CombatObjectives_killAll KillAll { get; set; }
#endif
        /// <summary>Achieved if all enemies with the `target` NodeEffect are dead.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public CombatObjectives_killTarget? KillTarget { get; set; }
#nullable restore
#else
        public CombatObjectives_killTarget KillTarget { get; set; }
#endif
        /// <summary>Achieved on the next operator turn after all `operatorStoryIds` have been played (one per operator turn).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public CombatObjectives_operator? Operator { get; set; }
#nullable restore
#else
        public CombatObjectives_operator Operator { get; set; }
#endif
        /// <summary>If true, achieved after other, unspecified conditions.</summary>
        public bool? Other { get; set; }
        /// <summary>Achieved if the timer expires.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public CombatObjectives_timer? Timer { get; set; }
#nullable restore
#else
        public CombatObjectives_timer Timer { get; set; }
#endif
        /// <summary>Achieved if all enemies with the `target` NodeEffect have less than `healthPercent`% health.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public CombatObjectives_woundTarget? WoundTarget { get; set; }
#nullable restore
#else
        public CombatObjectives_woundTarget WoundTarget { get; set; }
#endif
        /// <summary>
        /// Instantiates a new CombatObjectives and sets the default values.
        /// </summary>
        public CombatObjectives() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static CombatObjectives CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CombatObjectives();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"killAll", n => { KillAll = n.GetObjectValue<CombatObjectives_killAll>(CombatObjectives_killAll.CreateFromDiscriminatorValue); } },
                {"killTarget", n => { KillTarget = n.GetObjectValue<CombatObjectives_killTarget>(CombatObjectives_killTarget.CreateFromDiscriminatorValue); } },
                {"operator", n => { Operator = n.GetObjectValue<CombatObjectives_operator>(CombatObjectives_operator.CreateFromDiscriminatorValue); } },
                {"other", n => { Other = n.GetBoolValue(); } },
                {"timer", n => { Timer = n.GetObjectValue<CombatObjectives_timer>(CombatObjectives_timer.CreateFromDiscriminatorValue); } },
                {"woundTarget", n => { WoundTarget = n.GetObjectValue<CombatObjectives_woundTarget>(CombatObjectives_woundTarget.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<CombatObjectives_killAll>("killAll", KillAll);
            writer.WriteObjectValue<CombatObjectives_killTarget>("killTarget", KillTarget);
            writer.WriteObjectValue<CombatObjectives_operator>("operator", Operator);
            writer.WriteBoolValue("other", Other);
            writer.WriteObjectValue<CombatObjectives_timer>("timer", Timer);
            writer.WriteObjectValue<CombatObjectives_woundTarget>("woundTarget", WoundTarget);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
