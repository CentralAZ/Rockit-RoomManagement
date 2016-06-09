﻿using System;
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

        /// <summary>
        /// Gets the available resource quantity.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <param name="reservation">The reservation.</param>
        /// <returns></returns>
        public int GetAvailableResourceQuantity( Resource resource, Reservation reservation )
        {
            // For each new reservation summary, make sure that the quantities of existing summaries that come into contact with it
            // do not exceed the resource's quantity

            var rockContext = new RockContext();
            var reservationService = new ReservationService( rockContext );
            List<Reservation> newReservationList = new List<Reservation>() { reservation };
            var currentReservationSummaries = reservationService.GetReservationSummaries( reservationService.Queryable().Where( r => r.Id != reservation.Id ), DateTime.Now, DateTime.Now.AddDays( 3 ) );

            var reservedQuantities = reservationService.GetReservationSummaries( newReservationList.AsQueryable(), DateTime.Now, DateTime.Now.AddDays( 3 ) )
                .Select( newReservationSummary =>
                    currentReservationSummaries.Where( currentReservationSummary =>
                     ( currentReservationSummary.ReservationStartDateTime > newReservationSummary.ReservationStartDateTime || currentReservationSummary.ReservationEndDateTime > newReservationSummary.ReservationStartDateTime ) &&
                     ( currentReservationSummary.ReservationStartDateTime < newReservationSummary.ReservationEndDateTime || currentReservationSummary.ReservationEndDateTime < newReservationSummary.ReservationEndDateTime )
                    ).Sum( currentReservationSummary => currentReservationSummary.ReservationResources.Where( rr => rr.ResourceId == resource.Id ).Sum( rr => rr.Quantity ) )
               ) ;

            var maxReservedQuantity = reservedQuantities.Count() > 0 ? reservedQuantities.Max() : 0;
            return resource.Quantity - maxReservedQuantity;
        }
    }
}
