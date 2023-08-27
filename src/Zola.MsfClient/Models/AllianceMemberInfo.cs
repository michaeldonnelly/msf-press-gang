using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Info about a member of an alliance.
    /// </summary>
    public class AllianceMemberInfo : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Information about an alliance member.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public AllianceMemberCard? Card { get; set; }
#nullable restore
#else
        public AllianceMemberCard Card { get; set; }
#endif
        /// <summary>Temporary ID for the member in the alliance. When a member joins or leaves an alliance, all alliance member&apos;s handles are changed.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Id { get; set; }
#nullable restore
#else
        public string Id { get; set; }
#endif
        /// <summary>If `true`, indicates this record belongs to the current user.If `false` or omitted, indicates that this record does not belong to the current user.</summary>
        public bool? IsSelf { get; set; }
        /// <summary>A rank in an alliance.</summary>
        public AllianceRank? Rank { get; set; }
        /// <summary>
        /// Instantiates a new AllianceMemberInfo and sets the default values.
        /// </summary>
        public AllianceMemberInfo() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static AllianceMemberInfo CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AllianceMemberInfo();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"card", n => { Card = n.GetObjectValue<AllianceMemberCard>(AllianceMemberCard.CreateFromDiscriminatorValue); } },
                {"id", n => { Id = n.GetStringValue(); } },
                {"isSelf", n => { IsSelf = n.GetBoolValue(); } },
                {"rank", n => { Rank = n.GetEnumValue<AllianceRank>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<AllianceMemberCard>("card", Card);
            writer.WriteStringValue("id", Id);
            writer.WriteBoolValue("isSelf", IsSelf);
            writer.WriteEnumValue<AllianceRank>("rank", Rank);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
