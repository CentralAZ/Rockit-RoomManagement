using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rock.Data;
using Rock.Model;

namespace com.centralaz.RoomManagement.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class ReservationResourceService : Service<ReservationResource>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationResourceService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ReservationResourceService( RockContext context ) : base( context ) { }
    }
}
