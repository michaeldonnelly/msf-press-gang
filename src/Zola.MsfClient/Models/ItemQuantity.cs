using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// A quantity of items (used for rewards).Contains at most one of `item`, `oneOf`, `allOf`, or `chanceOf`.The meaning is as follows:- `item` indicates that particular item.- `oneOf` indicates a package containing a random weighted selection from among its children.- `allOf` indicates a package containing all of its children.- `chanceOf` indicates a package which has a chance of containing its child.If the ItemQuantity object contains none of those four, it represents an empty package.
    /// </summary>
    public class ItemQuantity : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The allOf property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<ItemQuantity>? AllOf { get; set; }
#nullable restore
#else
        public List<ItemQuantity> AllOf { get; set; }
#endif
        /// <summary>A quantity of items (used for rewards).Contains at most one of `item`, `oneOf`, `allOf`, or `chanceOf`.The meaning is as follows:- `item` indicates that particular item.- `oneOf` indicates a package containing a random weighted selection from among its children.- `allOf` indicates a package containing all of its children.- `chanceOf` indicates a package which has a chance of containing its child.If the ItemQuantity object contains none of those four, it represents an empty package.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ItemQuantity? ChanceOf { get; set; }
#nullable restore
#else
        public ItemQuantity ChanceOf { get; set; }
#endif
        /// <summary>If itemFormat=id, just the ID string. Otherwise, the full Item object.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Zola.MsfClient.Models.Item? Item { get; set; }
#nullable restore
#else
        public Zola.MsfClient.Models.Item Item { get; set; }
#endif
        /// <summary>If present, indicates a range of possible quantities, from `quantity` to `maxQuantity`.</summary>
        public int? MaxQuantity { get; set; }
        /// <summary>The oneOf property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<ItemQuantity>? OneOf { get; set; }
#nullable restore
#else
        public List<ItemQuantity> OneOf { get; set; }
#endif
        /// <summary>In the case of `oneOf` or `chanceOf`, indicates how many times the package is rolled/opened. Each pull can yield a different result.</summary>
        public int? Pulls { get; set; }
        /// <summary>The quantity of the item. (Not used for`oneOf`, `allOf`, or `chanceOf`.)</summary>
        public int? Quantity { get; set; }
        /// <summary>Reflects how often this ItemQuantity object is picked from among its siblings. (Only used for children of `oneOf`.)</summary>
        public int? Weight { get; set; }
        /// <summary>
        /// Instantiates a new ItemQuantity and sets the default values.
        /// </summary>
        public ItemQuantity() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static ItemQuantity CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ItemQuantity();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"allOf", n => { AllOf = n.GetCollectionOfObjectValues<ItemQuantity>(ItemQuantity.CreateFromDiscriminatorValue)?.ToList(); } },
                {"chanceOf", n => { ChanceOf = n.GetObjectValue<ItemQuantity>(ItemQuantity.CreateFromDiscriminatorValue); } },
                {"item", n => { Item = n.GetObjectValue<Zola.MsfClient.Models.Item>(Zola.MsfClient.Models.Item.CreateFromDiscriminatorValue); } },
                {"maxQuantity", n => { MaxQuantity = n.GetIntValue(); } },
                {"oneOf", n => { OneOf = n.GetCollectionOfObjectValues<ItemQuantity>(ItemQuantity.CreateFromDiscriminatorValue)?.ToList(); } },
                {"pulls", n => { Pulls = n.GetIntValue(); } },
                {"quantity", n => { Quantity = n.GetIntValue(); } },
                {"weight", n => { Weight = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<ItemQuantity>("allOf", AllOf);
            writer.WriteObjectValue<ItemQuantity>("chanceOf", ChanceOf);
            writer.WriteObjectValue<Zola.MsfClient.Models.Item>("item", Item);
            writer.WriteIntValue("maxQuantity", MaxQuantity);
            writer.WriteCollectionOfObjectValues<ItemQuantity>("oneOf", OneOf);
            writer.WriteIntValue("pulls", Pulls);
            writer.WriteIntValue("quantity", Quantity);
            writer.WriteIntValue("weight", Weight);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
