using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
using Zola.MsfClient.Game.V1.CharacterInstances;
using Zola.MsfClient.Game.V1.Characters;
using Zola.MsfClient.Game.V1.Dds;
using Zola.MsfClient.Game.V1.Decorations;
using Zola.MsfClient.Game.V1.Episodics;
using Zola.MsfClient.Game.V1.Events;
using Zola.MsfClient.Game.V1.Iso8Abilities;
using Zola.MsfClient.Game.V1.Items;
using Zola.MsfClient.Game.V1.Languages;
using Zola.MsfClient.Game.V1.Localizations;
using Zola.MsfClient.Game.V1.NodeCombats;
using Zola.MsfClient.Game.V1.OrbRewards;
using Zola.MsfClient.Game.V1.PickYourPoisons;
using Zola.MsfClient.Game.V1.RaidGroups;
using Zola.MsfClient.Game.V1.Raids;
using Zola.MsfClient.Game.V1.Scopes;
using Zola.MsfClient.Game.V1.Traits;
using Zola.MsfClient.Game.V1.UpgradeData;
namespace Zola.MsfClient.Game.V1 {
    /// <summary>
    /// Builds and executes requests for operations under \game\v1
    /// </summary>
    public class V1RequestBuilder : BaseRequestBuilder {
        /// <summary>The characterInstances property</summary>
        public CharacterInstancesRequestBuilder CharacterInstances { get =>
            new CharacterInstancesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The characters property</summary>
        public CharactersRequestBuilder Characters { get =>
            new CharactersRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The dds property</summary>
        public DdsRequestBuilder Dds { get =>
            new DdsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The decorations property</summary>
        public DecorationsRequestBuilder Decorations { get =>
            new DecorationsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The episodics property</summary>
        public EpisodicsRequestBuilder Episodics { get =>
            new EpisodicsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The events property</summary>
        public EventsRequestBuilder Events { get =>
            new EventsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The iso8Abilities property</summary>
        public Iso8AbilitiesRequestBuilder Iso8Abilities { get =>
            new Iso8AbilitiesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The items property</summary>
        public ItemsRequestBuilder Items { get =>
            new ItemsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The languages property</summary>
        public LanguagesRequestBuilder Languages { get =>
            new LanguagesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The localizations property</summary>
        public LocalizationsRequestBuilder Localizations { get =>
            new LocalizationsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The nodeCombats property</summary>
        public NodeCombatsRequestBuilder NodeCombats { get =>
            new NodeCombatsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The orbRewards property</summary>
        public OrbRewardsRequestBuilder OrbRewards { get =>
            new OrbRewardsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The pickYourPoisons property</summary>
        public PickYourPoisonsRequestBuilder PickYourPoisons { get =>
            new PickYourPoisonsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The raidGroups property</summary>
        public RaidGroupsRequestBuilder RaidGroups { get =>
            new RaidGroupsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The raids property</summary>
        public RaidsRequestBuilder Raids { get =>
            new RaidsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The scopes property</summary>
        public ScopesRequestBuilder Scopes { get =>
            new ScopesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The traits property</summary>
        public TraitsRequestBuilder Traits { get =>
            new TraitsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The upgradeData property</summary>
        public UpgradeDataRequestBuilder UpgradeData { get =>
            new UpgradeDataRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new V1RequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public V1RequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/game/v1", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new V1RequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public V1RequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/game/v1", rawUrl) {
        }
    }
}
