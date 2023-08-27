using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
using Zola.MsfClient.Player.V1.Auth.Consents;
namespace Zola.MsfClient.Player.V1.Auth {
    /// <summary>
    /// Builds and executes requests for operations under \player\v1\auth
    /// </summary>
    public class AuthRequestBuilder : BaseRequestBuilder {
        /// <summary>The consents property</summary>
        public ConsentsRequestBuilder Consents { get =>
            new ConsentsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new AuthRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public AuthRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/player/v1/auth", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new AuthRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public AuthRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/player/v1/auth", rawUrl) {
        }
    }
}
