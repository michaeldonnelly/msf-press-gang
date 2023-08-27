using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zola.MsfClient.Models {
    public class Stats : IAdditionalDataHolder, IParsable {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>(%)</summary>
        public int? Accuracy { get; set; }
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        [NotMapped]
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The armor property</summary>
        public int? Armor { get; set; }
        /// <summary>(%)</summary>
        public int? BlockAmount { get; set; }
        /// <summary>(%)</summary>
        public int? BlockChance { get; set; }
        /// <summary>(%)</summary>
        public int? CritChance { get; set; }
        /// <summary>(%)</summary>
        public int? CritDamageBonus { get; set; }
        /// <summary>The damage property</summary>
        public int? Damage { get; set; }
        /// <summary>(%)</summary>
        public int? DamageReduction { get; set; }
        /// <summary>(%)</summary>
        public int? DodgeChance { get; set; }
        /// <summary>(%)</summary>
        public int? ExtraHeal { get; set; }
        /// <summary>The focus property</summary>
        public int? Focus { get; set; }
        /// <summary>The health property</summary>
        public int? Health { get; set; }
        /// <summary>The resist property</summary>
        public int? Resist { get; set; }
        /// <summary>The speed property</summary>
        public int? Speed { get; set; }
        /// <summary>
        /// Instantiates a new StatsMember1 and sets the default values.
        /// </summary>
        public Stats() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static Stats CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Stats();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"accuracy", n => { Accuracy = n.GetIntValue(); } },
                {"armor", n => { Armor = n.GetIntValue(); } },
                {"blockAmount", n => { BlockAmount = n.GetIntValue(); } },
                {"blockChance", n => { BlockChance = n.GetIntValue(); } },
                {"critChance", n => { CritChance = n.GetIntValue(); } },
                {"critDamageBonus", n => { CritDamageBonus = n.GetIntValue(); } },
                {"damage", n => { Damage = n.GetIntValue(); } },
                {"damageReduction", n => { DamageReduction = n.GetIntValue(); } },
                {"dodgeChance", n => { DodgeChance = n.GetIntValue(); } },
                {"extraHeal", n => { ExtraHeal = n.GetIntValue(); } },
                {"focus", n => { Focus = n.GetIntValue(); } },
                {"health", n => { Health = n.GetIntValue(); } },
                {"resist", n => { Resist = n.GetIntValue(); } },
                {"speed", n => { Speed = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("accuracy", Accuracy);
            writer.WriteIntValue("armor", Armor);
            writer.WriteIntValue("blockAmount", BlockAmount);
            writer.WriteIntValue("blockChance", BlockChance);
            writer.WriteIntValue("critChance", CritChance);
            writer.WriteIntValue("critDamageBonus", CritDamageBonus);
            writer.WriteIntValue("damage", Damage);
            writer.WriteIntValue("damageReduction", DamageReduction);
            writer.WriteIntValue("dodgeChance", DodgeChance);
            writer.WriteIntValue("extraHeal", ExtraHeal);
            writer.WriteIntValue("focus", Focus);
            writer.WriteIntValue("health", Health);
            writer.WriteIntValue("resist", Resist);
            writer.WriteIntValue("speed", Speed);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
