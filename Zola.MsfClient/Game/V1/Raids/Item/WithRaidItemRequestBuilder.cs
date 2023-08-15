using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
using Zola.MsfClient.Game.V1.Raids.Item.Item;
using Zola.MsfClient.Models;
namespace Zola.MsfClient.Game.V1.Raids.Item {
    /// <summary>
    /// Builds and executes requests for operations under \game\v1\raids\{raidId}
    /// </summary>
    public class WithRaidItemRequestBuilder : BaseRequestBuilder {
        /// <summary>Gets an item from the Zola.MsfClient.game.v1.raids.item.item collection</summary>
        public WithRoomItemRequestBuilder this[string position] { get {
            var urlTplParams = new Dictionary<string, object>(PathParameters);
            if (!string.IsNullOrWhiteSpace(position)) urlTplParams.Add("roomId", position);
            return new WithRoomItemRequestBuilder(urlTplParams, RequestAdapter);
        } }
        /// <summary>
        /// Instantiates a new WithRaidItemRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithRaidItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/game/v1/raids/{raidId}{?lang*,itemFormat*,statsFormat*,traitFormat*,nodeInfo*,nodeReqs*,nodeRewards*,pieceInfo*,raidInfo*,raidMap*,raidRewards*,raidDiffs*,difficulty*,nodeCombat*,charInfo*,quantityFormat*}", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new WithRaidItemRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithRaidItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/game/v1/raids/{raidId}{?lang*,itemFormat*,statsFormat*,traitFormat*,nodeInfo*,nodeReqs*,nodeRewards*,pieceInfo*,raidInfo*,raidMap*,raidRewards*,raidDiffs*,difficulty*,nodeCombat*,charInfo*,quantityFormat*}", rawUrl) {
        }
        /// <summary>
        /// Gets information about a raid.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<WithRaidResponse?> GetAsync(Action<WithRaidItemRequestBuilderGetRequestConfiguration>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<WithRaidResponse> GetAsync(Action<WithRaidItemRequestBuilderGetRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"404", ErrorResponse.CreateFromDiscriminatorValue},
                {"472", ErrorResponse.CreateFromDiscriminatorValue},
                {"500", ErrorResponse.CreateFromDiscriminatorValue},
                {"552", ErrorResponse.CreateFromDiscriminatorValue},
                {"553", ErrorResponse.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<WithRaidResponse>(requestInfo, WithRaidResponse.CreateFromDiscriminatorValue, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Gets information about a raid.
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<WithRaidItemRequestBuilderGetRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<WithRaidItemRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new WithRaidItemRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Gets information about a raid.
        /// </summary>
        public class WithRaidItemRequestBuilderGetQueryParameters {
            /// <summary>Specifies how much metadata to include about each character. If `full`, returns name and portrait. If `none`, returns no CharacterInfo.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? CharInfo { get; set; }
#nullable restore
#else
            public string CharInfo { get; set; }
#endif
            /// <summary>Specifies the difficulty of interest. If omitted, then information for all difficulties is returned. (If `nodeCombat`=`full` and `difficulty` is omitted for a raid with difficulties, then all CharacterInstance objects are replaced with arrays, with [0] being the normal difficulty, [1] being difficulty 1, and so on.)</summary>
            public int? Difficulty { get; set; }
            /// <summary>If &quot;id&quot;, returns all Item objects as ID strings instead of JSON objects.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? ItemFormat { get; set; }
#nullable restore
#else
            public string ItemFormat { get; set; }
#endif
            /// <summary>A language code specifying the language to return results in. If you don&apos;t need localized strings at all, set to &quot;none&quot;.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? Lang { get; set; }
#nullable restore
#else
            public string Lang { get; set; }
#endif
            /// <summary>Specifies whether to include full combat info (`full`) or just the ID (`none`).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? NodeCombat { get; set; }
#nullable restore
#else
            public string NodeCombat { get; set; }
#endif
            /// <summary>Specifies how much node information to include for each node: none (`none`), whatever other parameters call out (`part`), or general information plus whatever other parameters call out (`full`).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? NodeInfo { get; set; }
#nullable restore
#else
            public string NodeInfo { get; set; }
#endif
            /// <summary>Specifies how much of the node requirements to include for each node.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? NodeReqs { get; set; }
#nullable restore
#else
            public string NodeReqs { get; set; }
#endif
            /// <summary>Specifies how much of the node rewards to include for each node.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? NodeRewards { get; set; }
#nullable restore
#else
            public string NodeRewards { get; set; }
#endif
            /// <summary>Specifies how much metadata to include about each top-level item.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? PieceInfo { get; set; }
#nullable restore
#else
            public string PieceInfo { get; set; }
#endif
            /// <summary>If &quot;local&quot;, returns all non-negative quantity and maxQuantity fields as localized strings instead of integers.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? QuantityFormat { get; set; }
#nullable restore
#else
            public string QuantityFormat { get; set; }
#endif
            /// <summary>Specifies how much of the difficulty information to include for each raid.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? RaidDiffs { get; set; }
#nullable restore
#else
            public string RaidDiffs { get; set; }
#endif
            /// <summary>Specifies how much the general raid information to include for each raid.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? RaidInfo { get; set; }
#nullable restore
#else
            public string RaidInfo { get; set; }
#endif
            /// <summary>Specifies how much of map information to include for each raid.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? RaidMap { get; set; }
#nullable restore
#else
            public string RaidMap { get; set; }
#endif
            /// <summary>Specifies how much of the raid reward information to include for each raid.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? RaidRewards { get; set; }
#nullable restore
#else
            public string RaidRewards { get; set; }
#endif
            /// <summary>If &quot;csv&quot;, returns all Stats, StatBoost, and Iso8 objects as CSV strings instead of JSON objects. Any omitted values default to 0 or &quot;none&quot;.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? StatsFormat { get; set; }
#nullable restore
#else
            public string StatsFormat { get; set; }
#endif
            /// <summary>If &quot;id&quot;, returns all Trait objects as ID strings instead of JSON objects.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? TraitFormat { get; set; }
#nullable restore
#else
            public string TraitFormat { get; set; }
#endif
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        public class WithRaidItemRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public WithRaidItemRequestBuilderGetQueryParameters QueryParameters { get; set; } = new WithRaidItemRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new WithRaidItemRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public WithRaidItemRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
    }
}
