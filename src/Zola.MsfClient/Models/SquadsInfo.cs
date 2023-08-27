using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Object containing information about a player&apos;s squads
    /// </summary>
    public class SquadsInfo : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The player&apos;s maximum number of squads.</summary>
        public int? MaxSquads { get; set; }
        /// <summary>Object containing a player&apos;s squads.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public SquadTabs? Tabs { get; set; }
#nullable restore
#else
        public SquadTabs Tabs { get; set; }
#endif
        /// <summary>
        /// Instantiates a new SquadsInfo and sets the default values.
        /// </summary>
        public SquadsInfo() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static SquadsInfo CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SquadsInfo();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"maxSquads", n => { MaxSquads = n.GetIntValue(); } },
                {"tabs", n => { Tabs = n.GetObjectValue<SquadTabs>(SquadTabs.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("maxSquads", MaxSquads);
            writer.WriteObjectValue<SquadTabs>("tabs", Tabs);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
