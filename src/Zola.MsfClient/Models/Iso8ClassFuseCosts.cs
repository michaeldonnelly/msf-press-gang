using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// The fuse costs for this class.
    /// </summary>
    public class Iso8ClassFuseCosts : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Object mapping level numbers or tier numbers (starting at 1) to costs.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public IndexedCosts? Armor { get; set; }
#nullable restore
#else
        public IndexedCosts Armor { get; set; }
#endif
        /// <summary>Object mapping level numbers or tier numbers (starting at 1) to costs.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public IndexedCosts? Damage { get; set; }
#nullable restore
#else
        public IndexedCosts Damage { get; set; }
#endif
        /// <summary>Object mapping level numbers or tier numbers (starting at 1) to costs.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public IndexedCosts? Focus { get; set; }
#nullable restore
#else
        public IndexedCosts Focus { get; set; }
#endif
        /// <summary>Object mapping level numbers or tier numbers (starting at 1) to costs.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public IndexedCosts? Health { get; set; }
#nullable restore
#else
        public IndexedCosts Health { get; set; }
#endif
        /// <summary>Object mapping level numbers or tier numbers (starting at 1) to costs.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public IndexedCosts? Resist { get; set; }
#nullable restore
#else
        public IndexedCosts Resist { get; set; }
#endif
        /// <summary>
        /// Instantiates a new Iso8ClassFuseCosts and sets the default values.
        /// </summary>
        public Iso8ClassFuseCosts() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static Iso8ClassFuseCosts CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Iso8ClassFuseCosts();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"armor", n => { Armor = n.GetObjectValue<IndexedCosts>(IndexedCosts.CreateFromDiscriminatorValue); } },
                {"damage", n => { Damage = n.GetObjectValue<IndexedCosts>(IndexedCosts.CreateFromDiscriminatorValue); } },
                {"focus", n => { Focus = n.GetObjectValue<IndexedCosts>(IndexedCosts.CreateFromDiscriminatorValue); } },
                {"health", n => { Health = n.GetObjectValue<IndexedCosts>(IndexedCosts.CreateFromDiscriminatorValue); } },
                {"resist", n => { Resist = n.GetObjectValue<IndexedCosts>(IndexedCosts.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<IndexedCosts>("armor", Armor);
            writer.WriteObjectValue<IndexedCosts>("damage", Damage);
            writer.WriteObjectValue<IndexedCosts>("focus", Focus);
            writer.WriteObjectValue<IndexedCosts>("health", Health);
            writer.WriteObjectValue<IndexedCosts>("resist", Resist);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
