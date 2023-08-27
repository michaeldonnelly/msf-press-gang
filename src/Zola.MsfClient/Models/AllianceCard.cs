using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Information about an alliance.
    /// </summary>
    public class AllianceCard : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Number of days of inactivity before automatic demotion.</summary>
        public int? DemoteDays { get; set; }
        /// <summary>The alliance&apos;s description.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Description { get; set; }
#nullable restore
#else
        public string Description { get; set; }
#endif
        /// <summary>A URL.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Icon { get; set; }
#nullable restore
#else
        public string Icon { get; set; }
#endif
        /// <summary>Alliance Identifier: `{aid}:{member_version}`. How an alliance is identified.`member_version` is a random value generated whenever anyone joins/leaves the alliance.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Id { get; set; }
#nullable restore
#else
        public string Id { get; set; }
#endif
        /// <summary>Number of days of inactivity before automatic kick.</summary>
        public int? KickDays { get; set; }
        /// <summary>Represents simple progress towards a particular objective.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public SimpleProgress? Level { get; set; }
#nullable restore
#else
        public SimpleProgress Level { get; set; }
#endif
        /// <summary>A rank in an alliance.</summary>
        public AllianceRank? ManagementRank { get; set; }
        /// <summary>The alliance&apos;s name.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Name { get; set; }
#nullable restore
#else
        public string Name { get; set; }
#endif
        /// <summary>The type of the alliance (public or private).</summary>
        public AllianceCard_type? Type { get; set; }
        /// <summary>A war league.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Zola.MsfClient.Models.WarLeague? WarLeague { get; set; }
#nullable restore
#else
        public Zola.MsfClient.Models.WarLeague WarLeague { get; set; }
#endif
        /// <summary>The number of war trophies the alliance has.</summary>
        public int? WarTrophies { get; set; }
        /// <summary>A war zone.Zone `1`: 1 AM GMT Tuesday, Thursday, SaturdayZone `2`: 7 AM GMT Tuesday, Thursday, SaturdayZone `3`: 1 PM GMT Tuesday, Thursday, SaturdayZone `4`: 7 PM GMT Tuesday, Thursday, Saturday</summary>
        public int? WarZone { get; set; }
        /// <summary>
        /// Instantiates a new AllianceCard and sets the default values.
        /// </summary>
        public AllianceCard() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static AllianceCard CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AllianceCard();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"demoteDays", n => { DemoteDays = n.GetIntValue(); } },
                {"description", n => { Description = n.GetStringValue(); } },
                {"icon", n => { Icon = n.GetStringValue(); } },
                {"id", n => { Id = n.GetStringValue(); } },
                {"kickDays", n => { KickDays = n.GetIntValue(); } },
                {"level", n => { Level = n.GetObjectValue<SimpleProgress>(SimpleProgress.CreateFromDiscriminatorValue); } },
                {"managementRank", n => { ManagementRank = n.GetEnumValue<AllianceRank>(); } },
                {"name", n => { Name = n.GetStringValue(); } },
                {"type", n => { Type = n.GetEnumValue<AllianceCard_type>(); } },
                {"warLeague", n => { WarLeague = n.GetObjectValue<Zola.MsfClient.Models.WarLeague>(Zola.MsfClient.Models.WarLeague.CreateFromDiscriminatorValue); } },
                {"warTrophies", n => { WarTrophies = n.GetIntValue(); } },
                {"warZone", n => { WarZone = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("demoteDays", DemoteDays);
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("icon", Icon);
            writer.WriteStringValue("id", Id);
            writer.WriteIntValue("kickDays", KickDays);
            writer.WriteObjectValue<SimpleProgress>("level", Level);
            writer.WriteEnumValue<AllianceRank>("managementRank", ManagementRank);
            writer.WriteStringValue("name", Name);
            writer.WriteEnumValue<AllianceCard_type>("type", Type);
            writer.WriteObjectValue<Zola.MsfClient.Models.WarLeague>("warLeague", WarLeague);
            writer.WriteIntValue("warTrophies", WarTrophies);
            writer.WriteIntValue("warZone", WarZone);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
