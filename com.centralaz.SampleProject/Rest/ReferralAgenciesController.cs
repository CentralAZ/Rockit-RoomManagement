using System.Linq;
using System.Net;
using System.Web.Http;

using com.centralaz.SampleProject.Model;

using Rock.Rest;
using Rock.Rest.Filters;

namespace com.centralaz.SampleProject.Rest
{
    /// <summary>
    /// REST API for Referral Agencies
    /// </summary>
    public class ReferralAgenciesController : ApiController<ReferralAgency>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReferralAgenciesController"/> class.
        /// </summary>
        public ReferralAgenciesController() : base( new ReferralAgencyService( new Data.SampleProjectContext() ) ) { }
    }
}
