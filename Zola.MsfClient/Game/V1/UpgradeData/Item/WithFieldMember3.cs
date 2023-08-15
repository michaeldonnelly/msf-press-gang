using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using Zola.MsfClient.Models;
namespace Zola.MsfClient.Game.V1.UpgradeData.Item {
    public class WithFieldMember3 : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Object mapping level numbers or tier numbers (starting at 1) to costs.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public IndexedCosts? Basic { get; set; }
#nullable restore
#else
        public IndexedCosts Basic { get; set; }
#endif
        /// <summary>Object mapping level numbers or tier numbers (starting at 1) to costs.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public IndexedCosts? Passive { get; set; }
#nullable restore
#else
        public IndexedCosts Passive { get; set; }
#endif
        /// <summary>Object mapping level numbers or tier numbers (starting at 1) to costs.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public IndexedCosts? Special { get; set; }
#nullable restore
#else
        public IndexedCosts Special { get; set; }
#endif
        /// <summary>Object mapping level numbers or tier numbers (starting at 1) to costs.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public IndexedCosts? Ultimate { get; set; }
#nullable restore
#else
        public IndexedCosts Ultimate { get; set; }
#endif
        /// <summary>
        /// Instantiates a new WithFieldMember3 and sets the default values.
        /// </summary>
        public WithFieldMember3() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static WithFieldMember3 CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WithFieldMember3();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"basic", n => { Basic = n.GetObjectValue<IndexedCosts>(IndexedCosts.CreateFromDiscriminatorValue); } },
                {"passive", n => { Passive = n.GetObjectValue<IndexedCosts>(IndexedCosts.CreateFromDiscriminatorValue); } },
                {"special", n => { Special = n.GetObjectValue<IndexedCosts>(IndexedCosts.CreateFromDiscriminatorValue); } },
                {"ultimate", n => { Ultimate = n.GetObjectValue<IndexedCosts>(IndexedCosts.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<IndexedCosts>("basic", Basic);
            writer.WriteObjectValue<IndexedCosts>("passive", Passive);
            writer.WriteObjectValue<IndexedCosts>("special", Special);
            writer.WriteObjectValue<IndexedCosts>("ultimate", Ultimate);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
