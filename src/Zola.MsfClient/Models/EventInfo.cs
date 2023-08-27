using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Information about a scheduled, running, or past event.
    /// </summary>
    public class EventInfo : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>If `true`, the event is claimable via the API.</summary>
        public bool? ApiClaimable { get; set; }
        /// <summary>Blitz information for an event. (For `blitz` type only.)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public BlitzEventInfo? Blitz { get; set; }
#nullable restore
#else
        public BlitzEventInfo Blitz { get; set; }
#endif
        /// <summary>A URL.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? CardArt { get; set; }
#nullable restore
#else
        public string CardArt { get; set; }
#endif
        /// <summary>(localized) Details shown inline when tapping the info button.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Details { get; set; }
#nullable restore
#else
        public string Details { get; set; }
#endif
        /// <summary>A date and time expressed as seconds since 1970 UTC.</summary>
        public long? EndTime { get; set; }
        /// <summary>Episodic information for an event. (For `episodic` type only.)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public EpisodicEventInfo? Episodic { get; set; }
#nullable restore
#else
        public EpisodicEventInfo Episodic { get; set; }
#endif
        /// <summary>An identifier for the instance of the event.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Id { get; set; }
#nullable restore
#else
        public string Id { get; set; }
#endif
        /// <summary>An array of identifiers suggesting locations for the event to appear.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? LocationHints { get; set; }
#nullable restore
#else
        public List<string> LocationHints { get; set; }
#endif
        /// <summary>Milestone information for an event. (For `milestone` type only.)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public MilestoneEventInfo? Milestone { get; set; }
#nullable restore
#else
        public MilestoneEventInfo Milestone { get; set; }
#endif
        /// <summary>(localized) The name of the event.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Name { get; set; }
#nullable restore
#else
        public string Name { get; set; }
#endif
        /// <summary>Pick Your Poison information for an event. (For `pickYourPoison` type only.)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public PickYourPoisonEventInfo? PickYourPoison { get; set; }
#nullable restore
#else
        public PickYourPoisonEventInfo PickYourPoison { get; set; }
#endif
        /// <summary>A URL.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? PopupArt { get; set; }
#nullable restore
#else
        public string PopupArt { get; set; }
#endif
        /// <summary>(localized) Details shown in a popup when tapping the info button.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? PopupDetails { get; set; }
#nullable restore
#else
        public string PopupDetails { get; set; }
#endif
        /// <summary>A date and time expressed as seconds since 1970 UTC.</summary>
        public long? StartTime { get; set; }
        /// <summary>(localized) Short description shown under the name.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? SubName { get; set; }
#nullable restore
#else
        public string SubName { get; set; }
#endif
        /// <summary>Tower information for an event. (For `tower` type only.)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public TowerEventInfo? Tower { get; set; }
#nullable restore
#else
        public TowerEventInfo Tower { get; set; }
#endif
        /// <summary>The type of event.</summary>
        public EventInfo_type? Type { get; set; }
        /// <summary>
        /// Instantiates a new EventInfo and sets the default values.
        /// </summary>
        public EventInfo() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static EventInfo CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new EventInfo();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"apiClaimable", n => { ApiClaimable = n.GetBoolValue(); } },
                {"blitz", n => { Blitz = n.GetObjectValue<BlitzEventInfo>(BlitzEventInfo.CreateFromDiscriminatorValue); } },
                {"cardArt", n => { CardArt = n.GetStringValue(); } },
                {"details", n => { Details = n.GetStringValue(); } },
                {"endTime", n => { EndTime = n.GetLongValue(); } },
                {"episodic", n => { Episodic = n.GetObjectValue<EpisodicEventInfo>(EpisodicEventInfo.CreateFromDiscriminatorValue); } },
                {"id", n => { Id = n.GetStringValue(); } },
                {"locationHints", n => { LocationHints = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"milestone", n => { Milestone = n.GetObjectValue<MilestoneEventInfo>(MilestoneEventInfo.CreateFromDiscriminatorValue); } },
                {"name", n => { Name = n.GetStringValue(); } },
                {"pickYourPoison", n => { PickYourPoison = n.GetObjectValue<PickYourPoisonEventInfo>(PickYourPoisonEventInfo.CreateFromDiscriminatorValue); } },
                {"popupArt", n => { PopupArt = n.GetStringValue(); } },
                {"popupDetails", n => { PopupDetails = n.GetStringValue(); } },
                {"startTime", n => { StartTime = n.GetLongValue(); } },
                {"subName", n => { SubName = n.GetStringValue(); } },
                {"tower", n => { Tower = n.GetObjectValue<TowerEventInfo>(TowerEventInfo.CreateFromDiscriminatorValue); } },
                {"type", n => { Type = n.GetEnumValue<EventInfo_type>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("apiClaimable", ApiClaimable);
            writer.WriteObjectValue<BlitzEventInfo>("blitz", Blitz);
            writer.WriteStringValue("cardArt", CardArt);
            writer.WriteStringValue("details", Details);
            writer.WriteLongValue("endTime", EndTime);
            writer.WriteObjectValue<EpisodicEventInfo>("episodic", Episodic);
            writer.WriteStringValue("id", Id);
            writer.WriteCollectionOfPrimitiveValues<string>("locationHints", LocationHints);
            writer.WriteObjectValue<MilestoneEventInfo>("milestone", Milestone);
            writer.WriteStringValue("name", Name);
            writer.WriteObjectValue<PickYourPoisonEventInfo>("pickYourPoison", PickYourPoison);
            writer.WriteStringValue("popupArt", PopupArt);
            writer.WriteStringValue("popupDetails", PopupDetails);
            writer.WriteLongValue("startTime", StartTime);
            writer.WriteStringValue("subName", SubName);
            writer.WriteObjectValue<TowerEventInfo>("tower", Tower);
            writer.WriteEnumValue<EventInfo_type>("type", Type);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
