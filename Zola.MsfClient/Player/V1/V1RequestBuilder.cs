using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
using Zola.MsfClient.Player.V1.Alliance;
using Zola.MsfClient.Player.V1.Auth;
using Zola.MsfClient.Player.V1.Card;
using Zola.MsfClient.Player.V1.Events;
using Zola.MsfClient.Player.V1.Inventory;
using Zola.MsfClient.Player.V1.Recruiting;
using Zola.MsfClient.Player.V1.Roster;
using Zola.MsfClient.Player.V1.Squads;
namespace Zola.MsfClient.Player.V1 {
    /// <summary>
    /// Builds and executes requests for operations under \player\v1
    /// </summary>
    public class V1RequestBuilder : BaseRequestBuilder {
        /// <summary>The alliance property</summary>
        public AllianceRequestBuilder Alliance { get =>
            new AllianceRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The auth property</summary>
        public AuthRequestBuilder Auth { get =>
            new AuthRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The card property</summary>
        public CardRequestBuilder Card { get =>
            new CardRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The events property</summary>
        public EventsRequestBuilder Events { get =>
            new EventsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The inventory property</summary>
        public InventoryRequestBuilder Inventory { get =>
            new InventoryRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The recruiting property</summary>
        public RecruitingRequestBuilder Recruiting { get =>
            new RecruitingRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The roster property</summary>
        public RosterRequestBuilder Roster { get =>
            new RosterRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The squads property</summary>
        public SquadsRequestBuilder Squads { get =>
            new SquadsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new V1RequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public V1RequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/player/v1", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new V1RequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public V1RequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/player/v1", rawUrl) {
        }
    }
}
