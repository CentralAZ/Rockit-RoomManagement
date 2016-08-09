using Rock.Data;

namespace com.centralaz.RoomManagement.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class ReservationStatusService : Service<ReservationStatus>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationStatusService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ReservationStatusService( RockContext context ) : base( context ) { }
    }
}
