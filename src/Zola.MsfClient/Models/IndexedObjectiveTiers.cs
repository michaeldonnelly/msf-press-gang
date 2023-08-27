using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Object mapping objective tier numbers to ObjectiveTier objects.`rewards` in each tier are additive (*i.e.* you can collect rewards for the highest tier you reach and each lower tier).`raidRewards` in each tier are not additive (*i.e.* you can only collect rewards for the highest tier you reach by the end of the raid).
    /// </summary>
    public class IndexedObjectiveTiers : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Describes a scoring tier applicable to an objective.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ObjectiveTier? Pound { get; set; }
#nullable restore
#else
        public ObjectiveTier Pound { get; set; }
#endif
        /// <summary>
        /// Instantiates a new IndexedObjectiveTiers and sets the default values.
        /// </summary>
        public IndexedObjectiveTiers() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static IndexedObjectiveTiers CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new IndexedObjectiveTiers();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"#", n => { Pound = n.GetObjectValue<ObjectiveTier>(ObjectiveTier.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<ObjectiveTier>("#", Pound);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
