using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Runtime.Serialization;
using Rock;
using Rock.Data;
using Rock.Model;
using DDay.iCal;
namespace com.centralaz.RoomManagement.Model
{
    /// <summary>
    /// A Room Reservation
    /// </summary>
    [Table( "_com_centralaz_RoomManagement_Reservation" )]
    [DataContract]
    public class Reservation : Rock.Data.Model<Reservation>, Rock.Data.IRockEntity
    {

        #region Entity Properties

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int ScheduleId { get; set; }

        [DataMember]
        public int? CampusId { get; set; }

        [DataMember]
        public int? ReservationMinistryId { get; set; }

        [DataMember]
        public int ReservationStatusId { get; set; }

        [DataMember]
        public int? RequesterAliasId { get; set; }

        [DataMember]
        public int? ApproverAliasId { get; set; }

        [DataMember]
        public int? SetupTime { get; set; }

        [DataMember]
        public int? CleanupTime { get; set; }

        [DataMember]
        public int? NumberAttending { get; set; }

        [DataMember]
        public bool IsApproved { get; set; }

        [DataMember]
        public string Note { get; set; }

        #endregion

        #region Virtual Properties

        public virtual Schedule Schedule { get; set; }

        public virtual Campus Campus { get; set; }

        public virtual ReservationMinistry ReservationMinistry { get; set; }

        public virtual ReservationStatus ReservationStatus { get; set; }

        public virtual PersonAlias RequesterAlias { get; set; }

        public virtual PersonAlias ApproverAlias { get; set; }

        public virtual ICollection<ReservationWorkflow> ReservationWorkflows
        {
            get { return _reservationWorkflows; }
            set { _reservationWorkflows = value; }
        }
        private ICollection<ReservationWorkflow> _reservationWorkflows;

        public virtual ICollection<ReservationResource> ReservationResources
        {
            get { return _reservationResources ?? ( _reservationResources = new Collection<ReservationResource>() ); }
            set { _reservationResources = value; }
        }
        private ICollection<ReservationResource> _reservationResources;

        public virtual ICollection<ReservationLocation> ReservationLocations
        {
            get { return _reservationLocations ?? ( _reservationLocations = new Collection<ReservationLocation>() ); }
            set { _reservationLocations = value; }
        }
        private ICollection<ReservationLocation> _reservationLocations;

        #endregion

        #region Methods

        /// <summary>
        /// Gets a list of scheduled start datetimes between the two specified dates, sorted by datetime.
        /// </summary>
        /// <param name="beginDateTime">The begin date time.</param>
        /// <param name="endDateTime">The end date time.</param>
        /// <returns></returns>
        public virtual List<ReservationDateTime> GetReservationTimes( DateTime beginDateTime, DateTime endDateTime )
        {
            if ( Schedule != null )
            {
                var result = new List<ReservationDateTime>();

                DDay.iCal.Event calEvent = Schedule.GetCalenderEvent();
                if ( calEvent != null && calEvent.DTStart != null )
                {
                    var occurrences = ScheduleICalHelper.GetOccurrences( calEvent, beginDateTime, endDateTime );
                    result = occurrences
                        .Where( a =>
                            a.Period != null &&
                            a.Period.StartTime != null &&
                            a.Period.EndTime != null )
                        .Select( a => new ReservationDateTime
                        {
                            StartDateTime = DateTime.SpecifyKind( a.Period.StartTime.Value, DateTimeKind.Local ),
                            EndDateTime = DateTime.SpecifyKind( a.Period.EndTime.Value, DateTimeKind.Local )
                        } )
                        .ToList();
                    {
                        // ensure the the datetime is DateTimeKind.Local since iCal returns DateTimeKind.UTC
                    }
                }

                return result;
            }
            else
            {
                return new List<ReservationDateTime>();
            }

        }

        #endregion

    }

    #region Entity Configuration


    public partial class ReservationConfiguration : EntityTypeConfiguration<Reservation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationConfiguration"/> class.
        /// </summary>
        public ReservationConfiguration()
        {
            this.HasRequired( r => r.Campus ).WithMany().HasForeignKey( r => r.CampusId ).WillCascadeOnDelete( false );
            this.HasRequired( r => r.ReservationMinistry ).WithMany().HasForeignKey( r => r.ReservationMinistryId ).WillCascadeOnDelete( false );
            this.HasRequired( r => r.ReservationStatus ).WithMany().HasForeignKey( r => r.ReservationStatusId ).WillCascadeOnDelete( false );
            this.HasRequired( r => r.Schedule ).WithMany().HasForeignKey( r => r.ScheduleId ).WillCascadeOnDelete( false );
            this.HasRequired( r => r.RequesterAlias ).WithMany().HasForeignKey( r => r.RequesterAliasId ).WillCascadeOnDelete( false );
            this.HasRequired( r => r.ApproverAlias ).WithMany().HasForeignKey( r => r.ApproverAliasId ).WillCascadeOnDelete( false );
        }
    }

    #endregion

    public class ReservationDateTime
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }

}
