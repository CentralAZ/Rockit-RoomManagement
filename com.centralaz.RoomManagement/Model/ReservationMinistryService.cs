using Rock.Data;

namespace com.centralaz.RoomManagement.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class ReservationMinistryService : Service<ReservationMinistry>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationMinistryService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ReservationMinistryService( RockContext context ) : base( context ) { }
    }
}
