using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using Zola.MsfClient.Models;
namespace Zola.MsfClient.Game.V1.PickYourPoisons.Item.Item {
    public class WithRoomResponse : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Information about a node. The `introStoryId` is played before character select at that node.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public NodeInfo? Data { get; set; }
#nullable restore
#else
        public NodeInfo Data { get; set; }
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
        /// Instantiates a new WithRoomResponse and sets the default values.
        /// </summary>
        public WithRoomResponse() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static WithRoomResponse CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WithRoomResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"data", n => { Data = n.GetObjectValue<NodeInfo>(NodeInfo.CreateFromDiscriminatorValue); } },
                {"meta", n => { Meta = n.GetObjectValue<Zola.MsfClient.Models.Meta>(Zola.MsfClient.Models.Meta.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<NodeInfo>("data", Data);
            writer.WriteObjectValue<Zola.MsfClient.Models.Meta>("meta", Meta);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
