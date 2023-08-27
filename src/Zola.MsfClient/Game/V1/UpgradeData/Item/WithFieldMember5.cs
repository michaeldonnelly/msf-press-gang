using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using Zola.MsfClient.Models;
namespace Zola.MsfClient.Game.V1.UpgradeData.Item {
    public class WithFieldMember5 : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The fuse costs for this class.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Iso8ClassFuseCosts? Blaster { get; set; }
#nullable restore
#else
        public Iso8ClassFuseCosts Blaster { get; set; }
#endif
        /// <summary>The fuse costs for this class.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Iso8ClassFuseCosts? Brawler { get; set; }
#nullable restore
#else
        public Iso8ClassFuseCosts Brawler { get; set; }
#endif
        /// <summary>The fuse costs for this class.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Iso8ClassFuseCosts? Controller { get; set; }
#nullable restore
#else
        public Iso8ClassFuseCosts Controller { get; set; }
#endif
        /// <summary>The fuse costs for this class.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Iso8ClassFuseCosts? Protector { get; set; }
#nullable restore
#else
        public Iso8ClassFuseCosts Protector { get; set; }
#endif
        /// <summary>The fuse costs for this class.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Iso8ClassFuseCosts? Support { get; set; }
#nullable restore
#else
        public Iso8ClassFuseCosts Support { get; set; }
#endif
        /// <summary>
        /// Instantiates a new WithFieldMember5 and sets the default values.
        /// </summary>
        public WithFieldMember5() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static WithFieldMember5 CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WithFieldMember5();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"blaster", n => { Blaster = n.GetObjectValue<Iso8ClassFuseCosts>(Iso8ClassFuseCosts.CreateFromDiscriminatorValue); } },
                {"brawler", n => { Brawler = n.GetObjectValue<Iso8ClassFuseCosts>(Iso8ClassFuseCosts.CreateFromDiscriminatorValue); } },
                {"controller", n => { Controller = n.GetObjectValue<Iso8ClassFuseCosts>(Iso8ClassFuseCosts.CreateFromDiscriminatorValue); } },
                {"protector", n => { Protector = n.GetObjectValue<Iso8ClassFuseCosts>(Iso8ClassFuseCosts.CreateFromDiscriminatorValue); } },
                {"support", n => { Support = n.GetObjectValue<Iso8ClassFuseCosts>(Iso8ClassFuseCosts.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<Iso8ClassFuseCosts>("blaster", Blaster);
            writer.WriteObjectValue<Iso8ClassFuseCosts>("brawler", Brawler);
            writer.WriteObjectValue<Iso8ClassFuseCosts>("controller", Controller);
            writer.WriteObjectValue<Iso8ClassFuseCosts>("protector", Protector);
            writer.WriteObjectValue<Iso8ClassFuseCosts>("support", Support);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
