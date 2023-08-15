using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
using Zola.MsfClient.Models;
namespace Zola.MsfClient.Game.V1.Dds.Item.Item {
    /// <summary>
    /// Builds and executes requests for operations under \game\v1\dds\{ddId}\{roomId}
    /// </summary>
    public class WithRoomItemRequestBuilder : BaseRequestBuilder {
        /// <summary>
        /// Instantiates a new WithRoomItemRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithRoomItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/game/v1/dds/{ddId}/{roomId}{?lang*,itemFormat*,statsFormat*,traitFormat*,nodeInfo*,nodeReqs*,nodeRewards*,pieceInfo*,raidMap*,nodeCombat*,charInfo*,quantityFormat*}", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new WithRoomItemRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithRoomItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/game/v1/dds/{ddId}/{roomId}{?lang*,itemFormat*,statsFormat*,traitFormat*,nodeInfo*,nodeReqs*,nodeRewards*,pieceInfo*,raidMap*,nodeCombat*,charInfo*,quantityFormat*}", rawUrl) {
        }
        /// <summary>
        /// Gets node information about a room in a dark dimension.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<WithRoomResponse?> GetAsync(Action<WithRoomItemRequestBuilderGetRequestConfiguration>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<WithRoomResponse> GetAsync(Action<WithRoomItemRequestBuilderGetRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"404", ErrorResponse.CreateFromDiscriminatorValue},
                {"472", ErrorResponse.CreateFromDiscriminatorValue},
                {"500", ErrorResponse.CreateFromDiscriminatorValue},
                {"552", ErrorResponse.CreateFromDiscriminatorValue},
                {"553", ErrorResponse.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<WithRoomResponse>(requestInfo, WithRoomResponse.CreateFromDiscriminatorValue, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Gets node information about a room in a dark dimension.
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<WithRoomItemRequestBuilderGetRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<WithRoomItemRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new WithRoomItemRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Gets node information about a room in a dark dimension.
        /// </summary>
        public class WithRoomItemRequestBuilderGetQueryParameters {
            /// <summary>Specifies how much metadata to include about each character. If `full`, returns name and portrait. If `none`, returns no CharacterInfo.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? CharInfo { get; set; }
#nullable restore
#else
            public string CharInfo { get; set; }
#endif
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
            /// <summary>Specifies how much node information to include for each node: whatever other parameters call out (`part`) or general information plus whatever other parameters call out (`full`).</summary>
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
            /// <summary>Specifies how much of map information to include for each raid.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? RaidMap { get; set; }
#nullable restore
#else
            public string RaidMap { get; set; }
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
        public class WithRoomItemRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public WithRoomItemRequestBuilderGetQueryParameters QueryParameters { get; set; } = new WithRoomItemRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new WithRoomItemRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public WithRoomItemRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
    }
}
