using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
using Zola.MsfClient.Models;
namespace Zola.MsfClient.Game.V1.UpgradeData.Item {
    /// <summary>
    /// Builds and executes requests for operations under \game\v1\upgradeData\{fieldId}
    /// </summary>
    public class WithFieldItemRequestBuilder : BaseRequestBuilder {
        /// <summary>
        /// Instantiates a new WithFieldItemRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithFieldItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/game/v1/upgradeData/{fieldId}{?lang*,itemFormat*,pieceInfo*,pieceDirectCost*,pieceFlatCost*,subPieceInfo*,quantityFormat*}", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new WithFieldItemRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithFieldItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/game/v1/upgradeData/{fieldId}{?lang*,itemFormat*,pieceInfo*,pieceDirectCost*,pieceFlatCost*,subPieceInfo*,quantityFormat*}", rawUrl) {
        }
        /// <summary>
        /// Gets information about costs and requirements for a specific kind of upgrade.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<WithFieldResponse?> GetAsync(Action<WithFieldItemRequestBuilderGetRequestConfiguration>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<WithFieldResponse> GetAsync(Action<WithFieldItemRequestBuilderGetRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"404", ErrorResponse.CreateFromDiscriminatorValue},
                {"472", ErrorResponse.CreateFromDiscriminatorValue},
                {"500", ErrorResponse.CreateFromDiscriminatorValue},
                {"552", ErrorResponse.CreateFromDiscriminatorValue},
                {"553", ErrorResponse.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<WithFieldResponse>(requestInfo, WithFieldResponse.CreateFromDiscriminatorValue, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Gets information about costs and requirements for a specific kind of upgrade.
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<WithFieldItemRequestBuilderGetRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<WithFieldItemRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new WithFieldItemRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Gets information about costs and requirements for a specific kind of upgrade.
        /// </summary>
        public class WithFieldItemRequestBuilderGetQueryParameters {
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
            /// <summary>Specifies whether to include the direct crafting cost of each top-level item (&quot;part&quot;) or all items (&quot;full&quot;).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? PieceDirectCost { get; set; }
#nullable restore
#else
            public string PieceDirectCost { get; set; }
#endif
            /// <summary>Specifies whether to include the flattened crafting cost of each top-level item.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? PieceFlatCost { get; set; }
#nullable restore
#else
            public string PieceFlatCost { get; set; }
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
            /// <summary>Specifies how much metadata to include about each of the sub-pieces.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? SubPieceInfo { get; set; }
#nullable restore
#else
            public string SubPieceInfo { get; set; }
#endif
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        public class WithFieldItemRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public WithFieldItemRequestBuilderGetQueryParameters QueryParameters { get; set; } = new WithFieldItemRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new WithFieldItemRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public WithFieldItemRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
    }
}
