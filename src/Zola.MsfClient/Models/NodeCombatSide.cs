using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Represents a side in combat.
    /// </summary>
    public class NodeCombatSide : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Describes a side&apos;s combat objectives. Achieving any one of the objectives is considered victory for that side. If the CombatObjectives object is omitted, victory is achieved if all enemies are dead. Otherwise, depending on which objective is achieved, the corresponding `endStoryId` is triggered.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public CombatObjectives? AnyObjectives { get; set; }
#nullable restore
#else
        public CombatObjectives AnyObjectives { get; set; }
#endif
        /// <summary>The combat waves for this side, in order. The `waveStoryId` for each combat wave is played the first time that combat wave is triggered.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<CombatWave>? Waves { get; set; }
#nullable restore
#else
        public List<CombatWave> Waves { get; set; }
#endif
        /// <summary>
        /// Instantiates a new NodeCombatSide and sets the default values.
        /// </summary>
        public NodeCombatSide() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static NodeCombatSide CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new NodeCombatSide();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"anyObjectives", n => { AnyObjectives = n.GetObjectValue<CombatObjectives>(CombatObjectives.CreateFromDiscriminatorValue); } },
                {"waves", n => { Waves = n.GetCollectionOfObjectValues<CombatWave>(CombatWave.CreateFromDiscriminatorValue)?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<CombatObjectives>("anyObjectives", AnyObjectives);
            writer.WriteCollectionOfObjectValues<CombatWave>("waves", Waves);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
