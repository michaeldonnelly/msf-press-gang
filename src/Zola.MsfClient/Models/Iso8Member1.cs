using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    public class Iso8Member1 : IAdditionalDataHolder, IParsable {
        /// <summary>Active class id, omitted if no active class.</summary>
        public Iso8Member1_active? Active { get; set; }
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>(pips equipped)</summary>
        public int? Armor { get; set; }
        /// <summary>(pips equipped)</summary>
        public int? Damage { get; set; }
        /// <summary>(pips equipped)</summary>
        public int? Focus { get; set; }
        /// <summary>(class level)</summary>
        public int? Fortifier { get; set; }
        /// <summary>(class level)</summary>
        public int? Healer { get; set; }
        /// <summary>(pips equipped)</summary>
        public int? Health { get; set; }
        /// <summary>The matrix tier. Defaults to green, if omitted.</summary>
        public Iso8Member1_matrix? Matrix { get; set; }
        /// <summary>(class level)</summary>
        public int? Raider { get; set; }
        /// <summary>(pips equipped)</summary>
        public int? Resist { get; set; }
        /// <summary>(class level)</summary>
        public int? Skirmisher { get; set; }
        /// <summary>(class level)</summary>
        public int? Striker { get; set; }
        /// <summary>
        /// Instantiates a new Iso8Member1 and sets the default values.
        /// </summary>
        public Iso8Member1() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static Iso8Member1 CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Iso8Member1();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"active", n => { Active = n.GetEnumValue<Iso8Member1_active>(); } },
                {"armor", n => { Armor = n.GetIntValue(); } },
                {"damage", n => { Damage = n.GetIntValue(); } },
                {"focus", n => { Focus = n.GetIntValue(); } },
                {"fortifier", n => { Fortifier = n.GetIntValue(); } },
                {"healer", n => { Healer = n.GetIntValue(); } },
                {"health", n => { Health = n.GetIntValue(); } },
                {"matrix", n => { Matrix = n.GetEnumValue<Iso8Member1_matrix>(); } },
                {"raider", n => { Raider = n.GetIntValue(); } },
                {"resist", n => { Resist = n.GetIntValue(); } },
                {"skirmisher", n => { Skirmisher = n.GetIntValue(); } },
                {"striker", n => { Striker = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteEnumValue<Iso8Member1_active>("active", Active);
            writer.WriteIntValue("armor", Armor);
            writer.WriteIntValue("damage", Damage);
            writer.WriteIntValue("focus", Focus);
            writer.WriteIntValue("fortifier", Fortifier);
            writer.WriteIntValue("healer", Healer);
            writer.WriteIntValue("health", Health);
            writer.WriteEnumValue<Iso8Member1_matrix>("matrix", Matrix);
            writer.WriteIntValue("raider", Raider);
            writer.WriteIntValue("resist", Resist);
            writer.WriteIntValue("skirmisher", Skirmisher);
            writer.WriteIntValue("striker", Striker);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
