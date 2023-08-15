using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
using Zola.MsfClient.Game.V1.CharacterInstances.Item.Item.Item.Item.Item.Item;
using Zola.MsfClient.Models;
namespace Zola.MsfClient.Game.V1.CharacterInstances.Item.Item.Item.Item.Item {
    /// <summary>
    /// Builds and executes requests for operations under \game\v1\characterInstances\{characterId}\{level}\{yellow}\{gearTier}\{gearTier}
    /// </summary>
    public class WithGearTierItemRequestBuilder : BaseRequestBuilder {
        /// <summary>Gets an item from the Zola.MsfClient.game.v1.characterInstances.item.item.item.item.item.item collection</summary>
        public WithSlot0ItemRequestBuilder this[string position] { get {
            var urlTplParams = new Dictionary<string, object>(PathParameters);
            if (!string.IsNullOrWhiteSpace(position)) urlTplParams.Add("slot0", position);
            return new WithSlot0ItemRequestBuilder(urlTplParams, RequestAdapter);
        } }
        /// <summary>
        /// Instantiates a new WithGearTierItemRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithGearTierItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/game/v1/characterInstances/{characterId}/{level}/{yellow}/{gearTier}/{gearTier}{?lang*,statsFormat*,itemFormat*,traitFormat*,mission*,charInfo*,abilityKits*,gearTiers*,pieceInfo*,pieceDirectCost*,pieceFlatCost*,subPieceInfo*,slot0*,slot1*,slot2*,slot3*,slot4*,slot5*,basic*,special*,ultimate*,passive*,iso8*,stark*,war*,quantityFormat*,page*,perPage*}", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new WithGearTierItemRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithGearTierItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/game/v1/characterInstances/{characterId}/{level}/{yellow}/{gearTier}/{gearTier}{?lang*,statsFormat*,itemFormat*,traitFormat*,mission*,charInfo*,abilityKits*,gearTiers*,pieceInfo*,pieceDirectCost*,pieceFlatCost*,subPieceInfo*,slot0*,slot1*,slot2*,slot3*,slot4*,slot5*,basic*,special*,ultimate*,passive*,iso8*,stark*,war*,quantityFormat*,page*,perPage*}", rawUrl) {
        }
        /// <summary>
        /// Gets information about a specific requested instance of a specific character.Any *one* of level, yellow, red, or gearTier can be set to &quot;all&quot;. In this case, an array of CharacterInstance objects will be returned, where only the following fields are filled in on each object: the stats field, the power field, the field set to &quot;all&quot;, and any fields which depend on that (for example, asking for &quot;max&quot; ultimate for &quot;all&quot; gear tiers).
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<WithGearTierResponse?> GetAsync(Action<WithGearTierItemRequestBuilderGetRequestConfiguration>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<WithGearTierResponse> GetAsync(Action<WithGearTierItemRequestBuilderGetRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"404", ErrorResponse.CreateFromDiscriminatorValue},
                {"422", ErrorResponse.CreateFromDiscriminatorValue},
                {"472", ErrorResponse.CreateFromDiscriminatorValue},
                {"500", ErrorResponse.CreateFromDiscriminatorValue},
                {"552", ErrorResponse.CreateFromDiscriminatorValue},
                {"553", ErrorResponse.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<WithGearTierResponse>(requestInfo, WithGearTierResponse.CreateFromDiscriminatorValue, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Gets information about a specific requested instance of a specific character.Any *one* of level, yellow, red, or gearTier can be set to &quot;all&quot;. In this case, an array of CharacterInstance objects will be returned, where only the following fields are filled in on each object: the stats field, the power field, the field set to &quot;all&quot;, and any fields which depend on that (for example, asking for &quot;max&quot; ultimate for &quot;all&quot; gear tiers).
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<WithGearTierItemRequestBuilderGetRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<WithGearTierItemRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new WithGearTierItemRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Gets information about a specific requested instance of a specific character.Any *one* of level, yellow, red, or gearTier can be set to &quot;all&quot;. In this case, an array of CharacterInstance objects will be returned, where only the following fields are filled in on each object: the stats field, the power field, the field set to &quot;all&quot;, and any fields which depend on that (for example, asking for &quot;max&quot; ultimate for &quot;all&quot; gear tiers).
        /// </summary>
        public class WithGearTierItemRequestBuilderGetQueryParameters {
            /// <summary>Specifies how much ability kit information to include about each character. (&quot;part&quot; = only their current ability levels)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? AbilityKits { get; set; }
#nullable restore
#else
            public string AbilityKits { get; set; }
#endif
            /// <summary>The basic ability level. If unspecified, defaults to the max for the requested character level and gear tier.</summary>
            public int? Basic { get; set; }
            /// <summary>Specifies how much metadata to include about each character. If &quot;part&quot;, only returns abilityKits/gearTiers fields. Note: if level, yellow, red, or gearTier is set to &quot;all&quot;, resulting in an array of CharacterInstance objects being returned, no CharacterInfo object is available and this parameter is ignored.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? CharInfo { get; set; }
#nullable restore
#else
            public string CharInfo { get; set; }
#endif
            /// <summary>Specifies how much gear tier information to include about each character. (&quot;part&quot; = only their current gear tier)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? GearTiers { get; set; }
#nullable restore
#else
            public string GearTiers { get; set; }
#endif
            /// <summary>Iso8 Object in CSV format, any trailing values taking their default. Alternatively, can be &quot;{class-id},max&quot; to represent that class at max iso8 or &quot;{class-id},#&quot; to represent that class at that number of iso8 across the board. In the shorthand notation, gems are folded to their equivalent matrix. For example, `fortifier,7` is equivalent to `blue,2,2,2,2,2,fortifier,7,7,7,7,7`. (Default: no Iso8.)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? Iso8 { get; set; }
#nullable restore
#else
            public string Iso8 { get; set; }
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
            /// <summary>If &quot;true&quot;, gets information for the mission variant of the character. If &quot;false&quot; (the default), gets information for the player variant of the character.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? Mission { get; set; }
#nullable restore
#else
            public string Mission { get; set; }
#endif
            /// <summary>Indicates the page number of the returned results, with `1` being the first page. For results numbered `1` through `perTotal`, page `n` will contain results numbered `(perPage * (n - 1)) + 1` through `perPage * n`. Only used if `perPage` is positive and defaults to the first page.</summary>
            public int? Page { get; set; }
            /// <summary>The passive ability level. If unspecified, defaults to the max for the requested character level and gear tier.</summary>
            public int? Passive { get; set; }
            /// <summary>The number of results per page. If unspecified, all results are returned.</summary>
            public int? PerPage { get; set; }
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
            /// <summary>True if top left gear piece is equipped.</summary>
            public bool? Slot0 { get; set; }
            /// <summary>True if middle left gear piece is equipped.</summary>
            public bool? Slot1 { get; set; }
            /// <summary>True if bottom left gear piece is equipped.</summary>
            public bool? Slot2 { get; set; }
            /// <summary>True if top right gear piece is equipped.</summary>
            public bool? Slot3 { get; set; }
            /// <summary>True if middle right gear piece is equipped.</summary>
            public bool? Slot4 { get; set; }
            /// <summary>True if bottom right gear piece is equipped.</summary>
            public bool? Slot5 { get; set; }
            /// <summary>The special ability level. If unspecified, defaults to the max for the requested character level and gear tier.</summary>
            public int? Special { get; set; }
            /// <summary>StatBoost Object in CSV format (5 primary stats only), any trailing values taking their default. Alternatively, can be &quot;max&quot; to represent max value. (Default: no stark tech.)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? Stark { get; set; }
#nullable restore
#else
            public string Stark { get; set; }
#endif
            /// <summary>If &quot;csv&quot;, returns all Stats, StatBoost, and Iso8 objects as CSV strings instead of JSON objects. Any omitted values default to 0 or &quot;none&quot;.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? StatsFormat { get; set; }
#nullable restore
#else
            public string StatsFormat { get; set; }
#endif
            /// <summary>Specifies how much metadata to include about each of the sub-pieces.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? SubPieceInfo { get; set; }
#nullable restore
#else
            public string SubPieceInfo { get; set; }
#endif
            /// <summary>If &quot;id&quot;, returns all Trait objects as ID strings instead of JSON objects.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? TraitFormat { get; set; }
#nullable restore
#else
            public string TraitFormat { get; set; }
#endif
            /// <summary>The ultimate ability level. If unspecified, defaults to the max for the requested character level and gear tier.</summary>
            public int? Ultimate { get; set; }
            /// <summary>War context used for calculating boosts. (Default: no war boosts.) &quot;attack&quot; or &quot;defend&quot;, optionally followed by a semicolon and then the room codes for which relevant rooms remain in the character&apos;s own helicarrier. (A = Armory, B = Barracks, C = Cargo Bay, H = Hangar, M = Med Bay) Advanced war contexts (see response specification) may also be used, but will result in slower processing times.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? War { get; set; }
#nullable restore
#else
            public string War { get; set; }
#endif
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        public class WithGearTierItemRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public WithGearTierItemRequestBuilderGetQueryParameters QueryParameters { get; set; } = new WithGearTierItemRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new WithGearTierItemRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public WithGearTierItemRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
    }
}
