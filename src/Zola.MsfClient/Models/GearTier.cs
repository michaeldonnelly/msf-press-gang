using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zola.MsfClient.Models {
    /// <summary>
    /// Information about a tier of gear for a character.
    /// </summary>
    public class GearTier : IAdditionalDataHolder, IParsable {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public int Level { get; set; }

        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        [NotMapped]
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Slots equippable in this tier, needed to advance to the next tier. Slots are listed in order, top to bottom on the left, then top to bottom on the right.</summary>
        public List<GearSlot>? Slots { get; set; }

        /// <summary>The stats that this tier of gear contributes to the character before any of the subsequent slots are equipped.</summary>
        //public Zola.MsfClient.Models.StatsGarbage? Stats { get; set; }
        public Stats? Stats { get; set; }

        /// <summary>
        /// Instantiates a new GearTier and sets the default values.
        /// </summary>
        public GearTier() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static GearTier CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new GearTier();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"slots", n =>
                    {
                        Slots = n.GetCollectionOfObjectValues<GearSlot>(GearSlot.CreateFromDiscriminatorValue)?.ToList();
                    }
                },
                {"stats", n =>
                    {
                        Stats = n.GetObjectValue<Zola.MsfClient.Models.Stats>(Zola.MsfClient.Models.Stats.CreateFromDiscriminatorValue);

                        //Stats = n.GetObjectValue<Zola.MsfClient.Models.StatsGarbage>(Zola.MsfClient.Models.StatsGarbage.CreateFromDiscriminatorValue);
                    }
                },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<GearSlot>("slots", Slots);
            writer.WriteObjectValue<Stats>("stats", Stats);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
