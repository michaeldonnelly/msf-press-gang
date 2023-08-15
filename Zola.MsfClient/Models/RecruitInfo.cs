using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Object containting information about a recruit
    /// </summary>
    public class RecruitInfo : IAdditionalDataHolder, IParsable {
        /// <summary>Object containing information about a recruit&apos;s ad. (Format will be changed in an upcoming release without notice.)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RecruitAd? Ad { get; set; }
#nullable restore
#else
        public RecruitAd Ad { get; set; }
#endif
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Information about a player.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public PlayerCard? Card { get; set; }
#nullable restore
#else
        public PlayerCard Card { get; set; }
#endif
        /// <summary>A date and time expressed as seconds since 1970 UTC.</summary>
        public long? Expiration { get; set; }
        /// <summary>The recruit&apos;s temporary identifier</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? RecruitId { get; set; }
#nullable restore
#else
        public string RecruitId { get; set; }
#endif
        /// <summary>
        /// Instantiates a new RecruitInfo and sets the default values.
        /// </summary>
        public RecruitInfo() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static RecruitInfo CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new RecruitInfo();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"ad", n => { Ad = n.GetObjectValue<RecruitAd>(RecruitAd.CreateFromDiscriminatorValue); } },
                {"card", n => { Card = n.GetObjectValue<PlayerCard>(PlayerCard.CreateFromDiscriminatorValue); } },
                {"expiration", n => { Expiration = n.GetLongValue(); } },
                {"recruitId", n => { RecruitId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<RecruitAd>("ad", Ad);
            writer.WriteObjectValue<PlayerCard>("card", Card);
            writer.WriteLongValue("expiration", Expiration);
            writer.WriteStringValue("recruitId", RecruitId);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
