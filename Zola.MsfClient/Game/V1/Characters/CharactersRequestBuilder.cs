using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
using Zola.MsfClient.Game.V1.Characters.Item;
using Zola.MsfClient.Models;
namespace Zola.MsfClient.Game.V1.Characters {
    /// <summary>
    /// Builds and executes requests for operations under \game\v1\characters
    /// </summary>
    public class CharactersRequestBuilder : BaseRequestBuilder {
        /// <summary>Gets an item from the Zola.MsfClient.game.v1.characters.item collection</summary>
        public WithCharacterItemRequestBuilder this[string position] { get {
            var urlTplParams = new Dictionary<string, object>(PathParameters);
            if (!string.IsNullOrWhiteSpace(position)) urlTplParams.Add("characterId", position);
            return new WithCharacterItemRequestBuilder(urlTplParams, RequestAdapter);
        } }
        /// <summary>
        /// Instantiates a new CharactersRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public CharactersRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/game/v1/characters{?lang*,statsFormat*,itemFormat*,traitFormat*,mission*,trait*,status*,charInfo*,costumes*,abilityKits*,gearTiers*,pieceInfo*,quantityFormat*,page*,perPage*}", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new CharactersRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public CharactersRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/game/v1/characters{?lang*,statsFormat*,itemFormat*,traitFormat*,mission*,trait*,status*,charInfo*,costumes*,abilityKits*,gearTiers*,pieceInfo*,quantityFormat*,page*,perPage*}", rawUrl) {
        }
        /// <summary>
        /// Gets information about a set of characters.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<CharactersResponse?> GetAsync(Action<CharactersRequestBuilderGetRequestConfiguration>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<CharactersResponse> GetAsync(Action<CharactersRequestBuilderGetRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"472", ErrorResponse.CreateFromDiscriminatorValue},
                {"500", ErrorResponse.CreateFromDiscriminatorValue},
                {"552", ErrorResponse.CreateFromDiscriminatorValue},
                {"553", ErrorResponse.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<CharactersResponse>(requestInfo, CharactersResponse.CreateFromDiscriminatorValue, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Gets information about a set of characters.
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<CharactersRequestBuilderGetRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<CharactersRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new CharactersRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Gets information about a set of characters.
        /// </summary>
        public class CharactersRequestBuilderGetQueryParameters {
            /// <summary>Specifies how much ability kit information to include about each character.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? AbilityKits { get; set; }
#nullable restore
#else
            public string AbilityKits { get; set; }
#endif
            /// <summary>Specifies how much metadata to include about each character.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? CharInfo { get; set; }
#nullable restore
#else
            public string CharInfo { get; set; }
#endif
            /// <summary>Specifies how much costume information to include about each character.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? Costumes { get; set; }
#nullable restore
#else
            public string Costumes { get; set; }
#endif
            /// <summary>Specifies how much gear tier information to include about each character.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? GearTiers { get; set; }
#nullable restore
#else
            public string GearTiers { get; set; }
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
            /// <summary>If &quot;true&quot;, gets information for the mission variants of the characters. If &quot;false&quot; (the default), gets information for the player variants of the characters. If &quot;both&quot; gets information for both.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? Mission { get; set; }
#nullable restore
#else
            public string Mission { get; set; }
#endif
            /// <summary>Indicates the page number of the returned results, with `1` being the first page. For results numbered `1` through `perTotal`, page `n` will contain results numbered `(perPage * (n - 1)) + 1` through `perPage * n`. Only used if `perPage` is positive and defaults to the first page.</summary>
            public int? Page { get; set; }
            /// <summary>The number of results per page. If unspecified, all results are returned.</summary>
            public int? PerPage { get; set; }
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
            /// <summary>If &quot;csv&quot;, returns all Stats, StatBoost, and Iso8 objects as CSV strings instead of JSON objects. Any omitted values default to 0 or &quot;none&quot;.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? StatsFormat { get; set; }
#nullable restore
#else
            public string StatsFormat { get; set; }
#endif
            /// <summary>Limits results to the specified status. (If omitted, results are not limited by status.)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? Status { get; set; }
#nullable restore
#else
            public string Status { get; set; }
#endif
            /// <summary>Limits results to the specified trait id. (If omitted, results are not limited by traits.)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? Trait { get; set; }
#nullable restore
#else
            public string Trait { get; set; }
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
        public class CharactersRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public CharactersRequestBuilderGetQueryParameters QueryParameters { get; set; } = new CharactersRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new charactersRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public CharactersRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
    }
}
