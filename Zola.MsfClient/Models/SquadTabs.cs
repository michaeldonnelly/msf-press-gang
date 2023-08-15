using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Object containing a player&apos;s squads.
    /// </summary>
    public class SquadTabs : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>List of arena squads.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? Arena { get; set; }
#nullable restore
#else
        public List<string> Arena { get; set; }
#endif
        /// <summary>List of blitz squads.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? Blitz { get; set; }
#nullable restore
#else
        public List<string> Blitz { get; set; }
#endif
        /// <summary>List of crucible squads.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? Crucible { get; set; }
#nullable restore
#else
        public List<string> Crucible { get; set; }
#endif
        /// <summary>List of raids squads.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? Raids { get; set; }
#nullable restore
#else
        public List<string> Raids { get; set; }
#endif
        /// <summary>List of roster squads.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? Roster { get; set; }
#nullable restore
#else
        public List<string> Roster { get; set; }
#endif
        /// <summary>List of tower squads.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? Tower { get; set; }
#nullable restore
#else
        public List<string> Tower { get; set; }
#endif
        /// <summary>List of war squads.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? War { get; set; }
#nullable restore
#else
        public List<string> War { get; set; }
#endif
        /// <summary>
        /// Instantiates a new SquadTabs and sets the default values.
        /// </summary>
        public SquadTabs() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static SquadTabs CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SquadTabs();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"arena", n => { Arena = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"blitz", n => { Blitz = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"crucible", n => { Crucible = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"raids", n => { Raids = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"roster", n => { Roster = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"tower", n => { Tower = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"war", n => { War = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfPrimitiveValues<string>("arena", Arena);
            writer.WriteCollectionOfPrimitiveValues<string>("blitz", Blitz);
            writer.WriteCollectionOfPrimitiveValues<string>("crucible", Crucible);
            writer.WriteCollectionOfPrimitiveValues<string>("raids", Raids);
            writer.WriteCollectionOfPrimitiveValues<string>("roster", Roster);
            writer.WriteCollectionOfPrimitiveValues<string>("tower", Tower);
            writer.WriteCollectionOfPrimitiveValues<string>("war", War);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
