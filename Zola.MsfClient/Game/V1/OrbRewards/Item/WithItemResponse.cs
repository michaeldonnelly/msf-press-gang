using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using Zola.MsfClient.Models;
namespace Zola.MsfClient.Game.V1.OrbRewards.Item {
    public class WithItemResponse : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>A quantity of items (used for rewards).Contains at most one of `item`, `oneOf`, `allOf`, or `chanceOf`.The meaning is as follows:- `item` indicates that particular item.- `oneOf` indicates a package containing a random weighted selection from among its children.- `allOf` indicates a package containing all of its children.- `chanceOf` indicates a package which has a chance of containing its child.If the ItemQuantity object contains none of those four, it represents an empty package.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ItemQuantity? Data { get; set; }
#nullable restore
#else
        public ItemQuantity Data { get; set; }
#endif
        /// <summary>Contains meta-information about the response.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Zola.MsfClient.Models.Meta? Meta { get; set; }
#nullable restore
#else
        public Zola.MsfClient.Models.Meta Meta { get; set; }
#endif
        /// <summary>
        /// Instantiates a new WithItemResponse and sets the default values.
        /// </summary>
        public WithItemResponse() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static WithItemResponse CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WithItemResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"data", n => { Data = n.GetObjectValue<ItemQuantity>(ItemQuantity.CreateFromDiscriminatorValue); } },
                {"meta", n => { Meta = n.GetObjectValue<Zola.MsfClient.Models.Meta>(Zola.MsfClient.Models.Meta.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<ItemQuantity>("data", Data);
            writer.WriteObjectValue<Zola.MsfClient.Models.Meta>("meta", Meta);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
