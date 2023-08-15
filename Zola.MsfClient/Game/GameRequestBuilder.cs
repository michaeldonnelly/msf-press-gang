using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
using Zola.MsfClient.Game.V1;
namespace Zola.MsfClient.Game {
    /// <summary>
    /// Builds and executes requests for operations under \game
    /// </summary>
    public class GameRequestBuilder : BaseRequestBuilder {
        /// <summary>The v1 property</summary>
        public V1RequestBuilder V1 { get =>
            new V1RequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new GameRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public GameRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/game", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new GameRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public GameRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/game", rawUrl) {
        }
    }
}
