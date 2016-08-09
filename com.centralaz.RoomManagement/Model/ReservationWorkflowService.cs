using Rock.Data;

namespace com.centralaz.RoomManagement.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class ReservationWorkflowService : Service<ReservationWorkflow>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationWorkflowService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ReservationWorkflowService( RockContext context ) : base( context ) { }
    }
}
