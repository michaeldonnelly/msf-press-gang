using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace Zola.MsfClient.Util.V1.GatedRefresh {
    /// <summary>
    /// Builds and executes requests for operations under \util\v1\gatedRefresh
    /// </summary>
    public class GatedRefreshRequestBuilder : BaseRequestBuilder {
        /// <summary>
        /// Instantiates a new GatedRefreshRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public GatedRefreshRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/util/v1/gatedRefresh", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new GatedRefreshRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public GatedRefreshRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/util/v1/gatedRefresh", rawUrl) {
        }
        /// <summary>
        /// Refresh tokens can only be used once. For security purposes, reusing a refresh token at the OAuth server will invalidate the entire token chain, forcing the player to log in to reauthorize your application again.If your application is running in a concurrent distributed environment, where it is difficult to ensure that the refresh token is not reused in a tight timeframe, you may consider refreshing your tokens using this gated refresh route instead.The API for the gated refresh route is the same as for the OAuth token refresh route, except that any additional requests (beyond the first) using the same refresh token within 20 seconds will generate a 473 GATED response. This will protect the token chain from being invalidated, giving your application the opportunity to wait for the new tokens being obtained in another thread (and/or processor) of your application.Note that reusing a refresh token after 20 seconds will no longer be gated, thus invalidating the entire token chain.Any error from this gateway will contain a `gatewayError` field, as documented in the error responses to the right. Otherwise, the response will be the one from the OAuth server, which may include additional errors according to the OAuth specification.NOTE: If your client is a server-side app, you will need to provide your credentials according to the http basic auth section at the top of the page.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<GatedRefreshResponse?> PostAsync(GatedRefreshPostRequestBody body, Action<GatedRefreshRequestBuilderPostRequestConfiguration>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<GatedRefreshResponse> PostAsync(GatedRefreshPostRequestBody body, Action<GatedRefreshRequestBuilderPostRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPostRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"400", GatedRefresh400Error.CreateFromDiscriminatorValue},
                {"473", GatedRefresh473Error.CreateFromDiscriminatorValue},
                {"500", GatedRefresh500Error.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<GatedRefreshResponse>(requestInfo, GatedRefreshResponse.CreateFromDiscriminatorValue, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Refresh tokens can only be used once. For security purposes, reusing a refresh token at the OAuth server will invalidate the entire token chain, forcing the player to log in to reauthorize your application again.If your application is running in a concurrent distributed environment, where it is difficult to ensure that the refresh token is not reused in a tight timeframe, you may consider refreshing your tokens using this gated refresh route instead.The API for the gated refresh route is the same as for the OAuth token refresh route, except that any additional requests (beyond the first) using the same refresh token within 20 seconds will generate a 473 GATED response. This will protect the token chain from being invalidated, giving your application the opportunity to wait for the new tokens being obtained in another thread (and/or processor) of your application.Note that reusing a refresh token after 20 seconds will no longer be gated, thus invalidating the entire token chain.Any error from this gateway will contain a `gatewayError` field, as documented in the error responses to the right. Otherwise, the response will be the one from the OAuth server, which may include additional errors according to the OAuth specification.NOTE: If your client is a server-side app, you will need to provide your credentials according to the http basic auth section at the top of the page.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPostRequestInformation(GatedRefreshPostRequestBody body, Action<GatedRefreshRequestBuilderPostRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToPostRequestInformation(GatedRefreshPostRequestBody body, Action<GatedRefreshRequestBuilderPostRequestConfiguration> requestConfiguration = default) {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.POST,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            requestInfo.SetContentFromParsable(RequestAdapter, "application/x-www-form-urlencoded", body);
            if (requestConfiguration != null) {
                var requestConfig = new GatedRefreshRequestBuilderPostRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        public class GatedRefreshRequestBuilderPostRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new gatedRefreshRequestBuilderPostRequestConfiguration and sets the default values.
            /// </summary>
            public GatedRefreshRequestBuilderPostRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
    }
}
