using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using Zola.MsfClient.Models;
namespace Zola.MsfClient.Game.V1.UpgradeData.Item {
    public class WithFieldResponse : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The data property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public WithField? Data { get; set; }
#nullable restore
#else
        public WithField Data { get; set; }
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
        /// Instantiates a new WithFieldResponse and sets the default values.
        /// </summary>
        public WithFieldResponse() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static WithFieldResponse CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WithFieldResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"data", n => { Data = n.GetObjectValue<WithField>(WithField.CreateFromDiscriminatorValue); } },
                {"meta", n => { Meta = n.GetObjectValue<Zola.MsfClient.Models.Meta>(Zola.MsfClient.Models.Meta.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<WithField>("data", Data);
            writer.WriteObjectValue<Zola.MsfClient.Models.Meta>("meta", Meta);
            writer.WriteAdditionalData(AdditionalData);
        }
        /// <summary>
        /// Composed type wrapper for classes integer, WithFieldMember1, IndexedShards, IndexedCosts, WithFieldMember2, WithFieldMember3, IndexedLevelRequirements, WithFieldMember4, WithFieldMember5
        /// </summary>
        public class WithField : IAdditionalDataHolder, IParsable {
            /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
            public IDictionary<string, object> AdditionalData { get; set; }
            /// <summary>Composed type representation for type IndexedCosts</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public Zola.MsfClient.Models.IndexedCosts? IndexedCosts { get; set; }
#nullable restore
#else
            public Zola.MsfClient.Models.IndexedCosts IndexedCosts { get; set; }
#endif
            /// <summary>Composed type representation for type IndexedLevelRequirements</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public Zola.MsfClient.Models.IndexedLevelRequirements? IndexedLevelRequirements { get; set; }
#nullable restore
#else
            public Zola.MsfClient.Models.IndexedLevelRequirements IndexedLevelRequirements { get; set; }
#endif
            /// <summary>Composed type representation for type IndexedShards</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public Zola.MsfClient.Models.IndexedShards? IndexedShards { get; set; }
#nullable restore
#else
            public Zola.MsfClient.Models.IndexedShards IndexedShards { get; set; }
#endif
            /// <summary>Composed type representation for type integer</summary>
            public int? Integer { get; set; }
            /// <summary>Serialization hint for the current wrapper.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? SerializationHint { get; set; }
#nullable restore
#else
            public string SerializationHint { get; set; }
#endif
            /// <summary>Composed type representation for type WithFieldMember1</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public Zola.MsfClient.Models.WithFieldMember1? WithFieldMember1 { get; set; }
#nullable restore
#else
            public Zola.MsfClient.Models.WithFieldMember1 WithFieldMember1 { get; set; }
#endif
            /// <summary>Composed type representation for type WithFieldMember2</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public Zola.MsfClient.Game.V1.UpgradeData.Item.WithFieldMember2? WithFieldMember2 { get; set; }
#nullable restore
#else
            public Zola.MsfClient.Game.V1.UpgradeData.Item.WithFieldMember2 WithFieldMember2 { get; set; }
#endif
            /// <summary>Composed type representation for type WithFieldMember3</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public Zola.MsfClient.Game.V1.UpgradeData.Item.WithFieldMember3? WithFieldMember3 { get; set; }
#nullable restore
#else
            public Zola.MsfClient.Game.V1.UpgradeData.Item.WithFieldMember3 WithFieldMember3 { get; set; }
#endif
            /// <summary>Composed type representation for type WithFieldMember4</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public Zola.MsfClient.Game.V1.UpgradeData.Item.WithFieldMember4? WithFieldMember4 { get; set; }
#nullable restore
#else
            public Zola.MsfClient.Game.V1.UpgradeData.Item.WithFieldMember4 WithFieldMember4 { get; set; }
#endif
            /// <summary>Composed type representation for type WithFieldMember5</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public Zola.MsfClient.Game.V1.UpgradeData.Item.WithFieldMember5? WithFieldMember5 { get; set; }
#nullable restore
#else
            public Zola.MsfClient.Game.V1.UpgradeData.Item.WithFieldMember5 WithFieldMember5 { get; set; }
#endif
            /// <summary>
            /// Instantiates a new WithField and sets the default values.
            /// </summary>
            public WithField() {
                AdditionalData = new Dictionary<string, object>();
            }
            /// <summary>
            /// Creates a new instance of the appropriate class based on discriminator value
            /// </summary>
            /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
            public static WithField CreateFromDiscriminatorValue(IParseNode parseNode) {
                _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
                var result = new WithField();
                if(parseNode.GetIntValue() is int integerValue) {
                    result.Integer = integerValue;
                }
                else {
                    result.IndexedCosts = new Zola.MsfClient.Models.IndexedCosts();
                    result.IndexedLevelRequirements = new Zola.MsfClient.Models.IndexedLevelRequirements();
                    result.IndexedShards = new Zola.MsfClient.Models.IndexedShards();
                    result.WithFieldMember1 = new Zola.MsfClient.Models.WithFieldMember1();
                    result.WithFieldMember2 = new Zola.MsfClient.Game.V1.UpgradeData.Item.WithFieldMember2();
                    result.WithFieldMember3 = new Zola.MsfClient.Game.V1.UpgradeData.Item.WithFieldMember3();
                    result.WithFieldMember4 = new Zola.MsfClient.Game.V1.UpgradeData.Item.WithFieldMember4();
                    result.WithFieldMember5 = new Zola.MsfClient.Game.V1.UpgradeData.Item.WithFieldMember5();
                }
                return result;
            }
            /// <summary>
            /// The deserialization information for the current model
            /// </summary>
            public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
                if(IndexedCosts != null || IndexedLevelRequirements != null || IndexedShards != null || WithFieldMember1 != null || WithFieldMember2 != null || WithFieldMember3 != null || WithFieldMember4 != null || WithFieldMember5 != null) {
                    return ParseNodeHelper.MergeDeserializersForIntersectionWrapper(IndexedCosts, IndexedLevelRequirements, IndexedShards, WithFieldMember1, WithFieldMember2, WithFieldMember3, WithFieldMember4, WithFieldMember5);
                }
                return new Dictionary<string, Action<IParseNode>>();
            }
            /// <summary>
            /// Serializes information the current object
            /// </summary>
            /// <param name="writer">Serialization writer to use to serialize this model</param>
            public void Serialize(ISerializationWriter writer) {
                _ = writer ?? throw new ArgumentNullException(nameof(writer));
                if(Integer != null) {
                    writer.WriteIntValue(null, Integer);
                }
                else {
                    writer.WriteObjectValue<Zola.MsfClient.Models.IndexedCosts>(null, IndexedCosts, IndexedLevelRequirements, IndexedShards, WithFieldMember1, WithFieldMember2, WithFieldMember3, WithFieldMember4, WithFieldMember5);
                }
                writer.WriteAdditionalData(AdditionalData);
            }
        }
    }
}
