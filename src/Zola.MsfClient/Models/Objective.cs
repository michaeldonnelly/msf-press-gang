using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>
    /// Describes an objective including its scoring tiers or ranges.The `progress` field is only present when requesting a player&apos;s progress toward the objective. For raids, the `progress` field represents the alliance&apos;s progress on the raid and the `contribution` field represents the player&apos;s damage contribution.
    /// </summary>
    public class Objective : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Represents progress towards a particular objective that may be ranked or have claimable tiers.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Zola.MsfClient.Models.Progress? Contribution { get; set; }
#nullable restore
#else
        public Zola.MsfClient.Models.Progress Contribution { get; set; }
#endif
        /// <summary>The maximum number of times the tiers can be completed. If omitted, defaults to 1.To test for repeatable tiers use `maxCompletions &gt; 1`.To test for non-repeatable tiers use `!(maxCompletions &gt; 1)`.</summary>
        public int? MaxCompletions { get; set; }
        /// <summary>The minimum score to qualify for range rewards.</summary>
        public int? MinRangeScore { get; set; }
        /// <summary>Represents progress towards a particular objective that may be ranked or have claimable tiers.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Zola.MsfClient.Models.Progress? Progress { get; set; }
#nullable restore
#else
        public Zola.MsfClient.Models.Progress Progress { get; set; }
#endif
        /// <summary>The scoring ranges for the objective.Range rewards are not additive and are granted solely based on whichever range applies for the final score.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<ObjectiveRange>? Ranges { get; set; }
#nullable restore
#else
        public List<ObjectiveRange> Ranges { get; set; }
#endif
        /// <summary>Object mapping objective tier numbers to ObjectiveTier objects.`rewards` in each tier are additive (*i.e.* you can collect rewards for the highest tier you reach and each lower tier).`raidRewards` in each tier are not additive (*i.e.* you can only collect rewards for the highest tier you reach by the end of the raid).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public IndexedObjectiveTiers? Tiers { get; set; }
#nullable restore
#else
        public IndexedObjectiveTiers Tiers { get; set; }
#endif
        /// <summary>
        /// Instantiates a new Objective and sets the default values.
        /// </summary>
        public Objective() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static Objective CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Objective();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"contribution", n => { Contribution = n.GetObjectValue<Zola.MsfClient.Models.Progress>(Zola.MsfClient.Models.Progress.CreateFromDiscriminatorValue); } },
                {"maxCompletions", n => { MaxCompletions = n.GetIntValue(); } },
                {"minRangeScore", n => { MinRangeScore = n.GetIntValue(); } },
                {"progress", n => { Progress = n.GetObjectValue<Zola.MsfClient.Models.Progress>(Zola.MsfClient.Models.Progress.CreateFromDiscriminatorValue); } },
                {"ranges", n => { Ranges = n.GetCollectionOfObjectValues<ObjectiveRange>(ObjectiveRange.CreateFromDiscriminatorValue)?.ToList(); } },
                {"tiers", n => { Tiers = n.GetObjectValue<IndexedObjectiveTiers>(IndexedObjectiveTiers.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<Zola.MsfClient.Models.Progress>("contribution", Contribution);
            writer.WriteIntValue("maxCompletions", MaxCompletions);
            writer.WriteIntValue("minRangeScore", MinRangeScore);
            writer.WriteObjectValue<Zola.MsfClient.Models.Progress>("progress", Progress);
            writer.WriteCollectionOfObjectValues<ObjectiveRange>("ranges", Ranges);
            writer.WriteObjectValue<IndexedObjectiveTiers>("tiers", Tiers);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
