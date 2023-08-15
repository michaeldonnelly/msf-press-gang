using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
using Zola.MsfClient.Game.V1.CharacterInstances.Item.Item.Item.Item.Item.Item.Item.Item.Item.Item.Item.Item.Item.Item;
namespace Zola.MsfClient.Game.V1.CharacterInstances.Item.Item.Item.Item.Item.Item.Item.Item.Item.Item.Item.Item.Item {
    /// <summary>
    /// Builds and executes requests for operations under \game\v1\characterInstances\{characterId}\{level}\{yellow}\{red}\{gearTier}\{slot0}\{slot1}\{slot2}\{slot3}\{slot4}\{slot5}\{basic}\{special}
    /// </summary>
    public class WithSpecialItemRequestBuilder : BaseRequestBuilder {
        /// <summary>Gets an item from the Zola.MsfClient.game.v1.characterInstances.item.item.item.item.item.item.item.item.item.item.item.item.item.item collection</summary>
        public WithPassiveItemRequestBuilder this[string position] { get {
            var urlTplParams = new Dictionary<string, object>(PathParameters);
            if (!string.IsNullOrWhiteSpace(position)) urlTplParams.Add("passive", position);
            return new WithPassiveItemRequestBuilder(urlTplParams, RequestAdapter);
        } }
        /// <summary>
        /// Instantiates a new WithSpecialItemRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithSpecialItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/game/v1/characterInstances/{characterId}/{level}/{yellow}/{red}/{gearTier}/{slot0}/{slot1}/{slot2}/{slot3}/{slot4}/{slot5}/{basic}/{special}", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new WithSpecialItemRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithSpecialItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/game/v1/characterInstances/{characterId}/{level}/{yellow}/{red}/{gearTier}/{slot0}/{slot1}/{slot2}/{slot3}/{slot4}/{slot5}/{basic}/{special}", rawUrl) {
        }
    }
}
