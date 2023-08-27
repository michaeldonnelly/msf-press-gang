using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// One way to obtain XP.
    /// </summary>
    public class UpgradeDataResponse_data_characterXpCosts : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The cost for this method of obtaining XP.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<ItemCost>? Cost { get; set; }
#nullable restore
#else
        public List<ItemCost> Cost { get; set; }
#endif
        /// <summary>The XP reward for this method of obtaining XP.</summary>
        public int? XpReward { get; set; }
        /// <summary>
        /// Instantiates a new upgradeDataResponse_data_characterXpCosts and sets the default values.
        /// </summary>
        public UpgradeDataResponse_data_characterXpCosts() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static UpgradeDataResponse_data_characterXpCosts CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new UpgradeDataResponse_data_characterXpCosts();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"cost", n => { Cost = n.GetCollectionOfObjectValues<ItemCost>(ItemCost.CreateFromDiscriminatorValue)?.ToList(); } },
                {"xpReward", n => { XpReward = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<ItemCost>("cost", Cost);
            writer.WriteIntValue("xpReward", XpReward);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
