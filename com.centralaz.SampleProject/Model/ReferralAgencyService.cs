using com.centralaz.SampleProject.Data;
using Rock.Model;

namespace com.centralaz.SampleProject.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class ReferralAgencyService : SampleProjectService<ReferralAgency>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReferralAgencyService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ReferralAgencyService( SampleProjectContext context ) : base( context ) { }

    }
}
