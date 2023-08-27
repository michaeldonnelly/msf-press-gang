using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
using Zola.MsfClient.Player.V1.Alliance.Card;
using Zola.MsfClient.Player.V1.Alliance.Members;
namespace Zola.MsfClient.Player.V1.Alliance {
    /// <summary>
    /// Builds and executes requests for operations under \player\v1\alliance
    /// </summary>
    public class AllianceRequestBuilder : BaseRequestBuilder {
        /// <summary>The card property</summary>
        public CardRequestBuilder Card { get =>
            new CardRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The members property</summary>
        public MembersRequestBuilder Members { get =>
            new MembersRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new AllianceRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public AllianceRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/player/v1/alliance", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new AllianceRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public AllianceRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/player/v1/alliance", rawUrl) {
        }
    }
}
