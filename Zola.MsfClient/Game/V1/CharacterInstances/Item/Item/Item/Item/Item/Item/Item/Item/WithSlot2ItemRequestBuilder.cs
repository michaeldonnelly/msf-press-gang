using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
using Zola.MsfClient.Game.V1.CharacterInstances.Item.Item.Item.Item.Item.Item.Item.Item.Item;
namespace Zola.MsfClient.Game.V1.CharacterInstances.Item.Item.Item.Item.Item.Item.Item.Item {
    /// <summary>
    /// Builds and executes requests for operations under \game\v1\characterInstances\{characterId}\{level}\{yellow}\{red}\{gearTier}\{slot0}\{slot1}\{slot2}
    /// </summary>
    public class WithSlot2ItemRequestBuilder : BaseRequestBuilder {
        /// <summary>Gets an item from the Zola.MsfClient.game.v1.characterInstances.item.item.item.item.item.item.item.item.item collection</summary>
        public WithSlot3ItemRequestBuilder this[string position] { get {
            var urlTplParams = new Dictionary<string, object>(PathParameters);
            if (!string.IsNullOrWhiteSpace(position)) urlTplParams.Add("slot3", position);
            return new WithSlot3ItemRequestBuilder(urlTplParams, RequestAdapter);
        } }
        /// <summary>
        /// Instantiates a new WithSlot2ItemRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithSlot2ItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/game/v1/characterInstances/{characterId}/{level}/{yellow}/{red}/{gearTier}/{slot0}/{slot1}/{slot2}", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new WithSlot2ItemRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithSlot2ItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/game/v1/characterInstances/{characterId}/{level}/{yellow}/{red}/{gearTier}/{slot0}/{slot1}/{slot2}", rawUrl) {
        }
    }
}
