using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zola.MsfClient.Models {
    /// <summary>
    /// Information about one level of an ability.
    /// </summary>
    public class AbilityLevel : IAdditionalDataHolder, IParsable {

        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        [NotMapped]
        public IDictionary<string, object> AdditionalData { get; set; }

        public int Level { get; set; }
        /// <summary>How much energy the ability costs to use.</summary>
        public int? CostEnergy { get; set; }

        /// <summary>(localized)</summary>
        public string? Description { get; set; }

        /// <summary>(localized) The bonuses of upgrading from this level to the next one.</summary>
        public string? NextUpgrade { get; set; }

        /// <summary>The cost to upgrade to the next ability level (if it differs from the default ability upgrade costs)</summary>
        [NotMapped]   // maybe later - this is causing some sort of drama now
        public List<ItemCost>? NextUpgradeCosts { get; set; }

        /// <summary>How much energy the ability starts with.</summary>
        public int? StartEnergy { get; set; }

        /// <summary>
        /// Instantiates a new AbilityLevel and sets the default values.
        /// </summary>
        public AbilityLevel() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static AbilityLevel CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AbilityLevel();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"costEnergy", n => { CostEnergy = n.GetIntValue(); } },
                {"description", n => { Description = n.GetStringValue(); } },
                {"nextUpgrade", n => { NextUpgrade = n.GetStringValue(); } },
                {"nextUpgradeCosts", n => { NextUpgradeCosts = n.GetCollectionOfObjectValues<ItemCost>(ItemCost.CreateFromDiscriminatorValue)?.ToList(); } },
                {"startEnergy", n => { StartEnergy = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("costEnergy", CostEnergy);
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("nextUpgrade", NextUpgrade);
            writer.WriteCollectionOfObjectValues<ItemCost>("nextUpgradeCosts", NextUpgradeCosts);
            writer.WriteIntValue("startEnergy", StartEnergy);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
