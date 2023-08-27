using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Information about an Episodic.
    /// </summary>
    public class EpisodicInfo : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Object mapping chapter numbers (starting at 1) to ChapterInfo objects.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public IndexedChapterInfos? Chapters { get; set; }
#nullable restore
#else
        public IndexedChapterInfos Chapters { get; set; }
#endif
        /// <summary>(localized) Details shown inline when tapping the info button.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Details { get; set; }
#nullable restore
#else
        public string Details { get; set; }
#endif
        /// <summary>For Event Campaigns, information about the Event Campaign Group that they are a part of.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public EventCampaignGroup? Group { get; set; }
#nullable restore
#else
        public EventCampaignGroup Group { get; set; }
#endif
        /// <summary>The `episodicId` of the episodic.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Id { get; set; }
#nullable restore
#else
        public string Id { get; set; }
#endif
        /// <summary>(localized)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Name { get; set; }
#nullable restore
#else
        public string Name { get; set; }
#endif
        /// <summary>The localized prefix name for each node in the episodic. For example, &quot;HEROES&quot; in &quot;HEROES 1-1&quot;.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? NodeName { get; set; }
#nullable restore
#else
        public string NodeName { get; set; }
#endif
        /// <summary>The number of chapters in this episodic.</summary>
        public int? NumChapters { get; set; }
        /// <summary>Represents requirements.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Zola.MsfClient.Models.Requirements? Requirements { get; set; }
#nullable restore
#else
        public Zola.MsfClient.Models.Requirements Requirements { get; set; }
#endif
        /// <summary>(localized) Short description shown under the name.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? SubName { get; set; }
#nullable restore
#else
        public string SubName { get; set; }
#endif
        /// <summary>
        /// Instantiates a new EpisodicInfo and sets the default values.
        /// </summary>
        public EpisodicInfo() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static EpisodicInfo CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new EpisodicInfo();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"chapters", n => { Chapters = n.GetObjectValue<IndexedChapterInfos>(IndexedChapterInfos.CreateFromDiscriminatorValue); } },
                {"details", n => { Details = n.GetStringValue(); } },
                {"group", n => { Group = n.GetObjectValue<EventCampaignGroup>(EventCampaignGroup.CreateFromDiscriminatorValue); } },
                {"id", n => { Id = n.GetStringValue(); } },
                {"name", n => { Name = n.GetStringValue(); } },
                {"nodeName", n => { NodeName = n.GetStringValue(); } },
                {"numChapters", n => { NumChapters = n.GetIntValue(); } },
                {"requirements", n => { Requirements = n.GetObjectValue<Zola.MsfClient.Models.Requirements>(Zola.MsfClient.Models.Requirements.CreateFromDiscriminatorValue); } },
                {"subName", n => { SubName = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<IndexedChapterInfos>("chapters", Chapters);
            writer.WriteStringValue("details", Details);
            writer.WriteObjectValue<EventCampaignGroup>("group", Group);
            writer.WriteStringValue("id", Id);
            writer.WriteStringValue("name", Name);
            writer.WriteStringValue("nodeName", NodeName);
            writer.WriteIntValue("numChapters", NumChapters);
            writer.WriteObjectValue<Zola.MsfClient.Models.Requirements>("requirements", Requirements);
            writer.WriteStringValue("subName", SubName);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
