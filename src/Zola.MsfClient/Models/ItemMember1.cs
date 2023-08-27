using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zola.MsfClient.Models {
    public class ItemMember1 : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        [NotMapped]
        public IDictionary<string, object> AdditionalData { get; set; }

        //[ForeignKey(CharacterInfo)]
        public string? CharacterId { get; set; }

        public string? Description { get; set; }

        /// <summary>Cost to craft this item in next-largest units. Used for gear only.</summary>
        [NotMapped]
        public List<ItemCost>? DirectCost { get; set; }

        /// <summary>Cost to craft this item in smallest units. Used for gear only.</summary>
        [NotMapped]
        public List<ItemCost>? FlatCost { get; set; }

        /// <summary>For costumes, a full-body image of the costume, if available.</summary>
        public string? FullArt { get; set; }

        /// <summary>A URL.</summary>
        public string? Icon { get; set; }

        /// <summary>The item ID.</summary>
        public string? Id { get; set; }

        /// <summary>If `true`, the item is a calendar.</summary>
        public bool? IsCalendar { get; set; }

        /// <summary>If `true`, the item is an orb.</summary>
        public bool? IsOrb { get; set; }

        /// <summary>(localized)</summary>
        public string? Name { get; set; }

        /// <summary>If `true`, the item does not use decorations.</summary>
        public bool? NoDeco { get; set; }

        /// <summary>If `true`, the item cannot be owned in the inventory.</summary>
        public bool? NoInv { get; set; }

        /// <summary>For costumes, the art used for this item in the in-game shop. (Omitted if no art is available.)</summary>
        public string? ShopArt { get; set; }

        /// <summary>Used for gear only.</summary>
        public Zola.MsfClient.Models.Stats? Stats { get; set; }

        /// <summary>Used for gear only.</summary>
        public int? Tier { get; set; }

        /// <summary>
        /// Instantiates a new ItemMember1 and sets the default values.
        /// </summary>
        public ItemMember1() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static ItemMember1 CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ItemMember1();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"characterId", n => { CharacterId = n.GetStringValue(); } },
                {"description", n => { Description = n.GetStringValue(); } },
                {"directCost", n => { DirectCost = n.GetCollectionOfObjectValues<ItemCost>(ItemCost.CreateFromDiscriminatorValue)?.ToList(); } },
                {"flatCost", n => { FlatCost = n.GetCollectionOfObjectValues<ItemCost>(ItemCost.CreateFromDiscriminatorValue)?.ToList(); } },
                {"fullArt", n => { FullArt = n.GetStringValue(); } },
                {"icon", n => { Icon = n.GetStringValue(); } },
                {"id", n => { Id = n.GetStringValue(); } },
                {"isCalendar", n => { IsCalendar = n.GetBoolValue(); } },
                {"isOrb", n => { IsOrb = n.GetBoolValue(); } },
                {"name", n => { Name = n.GetStringValue(); } },
                {"noDeco", n => { NoDeco = n.GetBoolValue(); } },
                {"noInv", n => { NoInv = n.GetBoolValue(); } },
                {"shopArt", n => { ShopArt = n.GetStringValue(); } },
                {"stats", n => { Stats = n.GetObjectValue<Zola.MsfClient.Models.Stats>(Zola.MsfClient.Models.Stats.CreateFromDiscriminatorValue); } },
                {"tier", n => { Tier = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("characterId", CharacterId);
            writer.WriteStringValue("description", Description);
            writer.WriteCollectionOfObjectValues<ItemCost>("directCost", DirectCost);
            writer.WriteCollectionOfObjectValues<ItemCost>("flatCost", FlatCost);
            writer.WriteStringValue("fullArt", FullArt);
            writer.WriteStringValue("icon", Icon);
            writer.WriteStringValue("id", Id);
            writer.WriteBoolValue("isCalendar", IsCalendar);
            writer.WriteBoolValue("isOrb", IsOrb);
            writer.WriteStringValue("name", Name);
            writer.WriteBoolValue("noDeco", NoDeco);
            writer.WriteBoolValue("noInv", NoInv);
            writer.WriteStringValue("shopArt", ShopArt);
            writer.WriteObjectValue<Zola.MsfClient.Models.Stats>("stats", Stats);
            writer.WriteIntValue("tier", Tier);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
