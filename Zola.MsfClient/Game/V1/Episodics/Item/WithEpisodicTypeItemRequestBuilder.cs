using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
using Zola.MsfClient.Game.V1.Episodics.Item.Item;
using Zola.MsfClient.Models;
namespace Zola.MsfClient.Game.V1.Episodics.Item {
    /// <summary>
    /// Builds and executes requests for operations under \game\v1\episodics\{episodicType}
    /// </summary>
    public class WithEpisodicTypeItemRequestBuilder : BaseRequestBuilder {
        /// <summary>Gets an item from the Zola.MsfClient.game.v1.episodics.item.item collection</summary>
        public WithEpisodicItemRequestBuilder this[string position] { get {
            var urlTplParams = new Dictionary<string, object>(PathParameters);
            if (!string.IsNullOrWhiteSpace(position)) urlTplParams.Add("episodicId", position);
            return new WithEpisodicItemRequestBuilder(urlTplParams, RequestAdapter);
        } }
        /// <summary>
        /// Instantiates a new WithEpisodicTypeItemRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithEpisodicTypeItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/game/v1/episodics/{episodicType}{?lang*,statsFormat*,itemFormat*,traitFormat*,quantityFormat*,page*,perPage*}", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new WithEpisodicTypeItemRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithEpisodicTypeItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/game/v1/episodics/{episodicType}{?lang*,statsFormat*,itemFormat*,traitFormat*,quantityFormat*,page*,perPage*}", rawUrl) {
        }
        /// <summary>
        /// Gets information about a set of episodics.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<WithEpisodicTypeResponse?> GetAsync(Action<WithEpisodicTypeItemRequestBuilderGetRequestConfiguration>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<WithEpisodicTypeResponse> GetAsync(Action<WithEpisodicTypeItemRequestBuilderGetRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"404", ErrorResponse.CreateFromDiscriminatorValue},
                {"472", ErrorResponse.CreateFromDiscriminatorValue},
                {"500", ErrorResponse.CreateFromDiscriminatorValue},
                {"552", ErrorResponse.CreateFromDiscriminatorValue},
                {"553", ErrorResponse.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<WithEpisodicTypeResponse>(requestInfo, WithEpisodicTypeResponse.CreateFromDiscriminatorValue, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Gets information about a set of episodics.
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<WithEpisodicTypeItemRequestBuilderGetRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<WithEpisodicTypeItemRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new WithEpisodicTypeItemRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Gets information about a set of episodics.
        /// </summary>
        public class WithEpisodicTypeItemRequestBuilderGetQueryParameters {
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
            /// <summary>Indicates the page number of the returned results, with `1` being the first page. For results numbered `1` through `perTotal`, page `n` will contain results numbered `(perPage * (n - 1)) + 1` through `perPage * n`. Only used if `perPage` is positive and defaults to the first page.</summary>
            public int? Page { get; set; }
            /// <summary>The number of results per page. If unspecified, all results are returned.</summary>
            public int? PerPage { get; set; }
            /// <summary>If &quot;local&quot;, returns all non-negative quantity and maxQuantity fields as localized strings instead of integers.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? QuantityFormat { get; set; }
#nullable restore
#else
            public string QuantityFormat { get; set; }
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
        public class WithEpisodicTypeItemRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public WithEpisodicTypeItemRequestBuilderGetQueryParameters QueryParameters { get; set; } = new WithEpisodicTypeItemRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new WithEpisodicTypeItemRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public WithEpisodicTypeItemRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
    }
}
