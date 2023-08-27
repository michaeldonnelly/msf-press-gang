using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
using Zola.MsfClient.Player.V1.Recruiting.Recruits;
namespace Zola.MsfClient.Player.V1.Recruiting {
    /// <summary>
    /// Builds and executes requests for operations under \player\v1\recruiting
    /// </summary>
    public class RecruitingRequestBuilder : BaseRequestBuilder {
        /// <summary>The recruits property</summary>
        public RecruitsRequestBuilder Recruits { get =>
            new RecruitsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new RecruitingRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public RecruitingRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/player/v1/recruiting", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new RecruitingRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public RecruitingRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/player/v1/recruiting", rawUrl) {
        }
    }
}
