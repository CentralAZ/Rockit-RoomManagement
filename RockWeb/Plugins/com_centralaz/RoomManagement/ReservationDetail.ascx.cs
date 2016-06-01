using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;
using com.centralaz.RoomManagement.Model;
using DDay.iCal;
using Rock;
using Rock.Attribute;
using Rock.Data;
using Rock.Model;
using Rock.Web;
using Rock.Web.Cache;
using Rock.Web.UI;
namespace RockWeb.Plugins.com_centralaz.RoomManagement
{

    [DisplayName( "Reservation Detail" )]
    [Category( "com_centralaz > Room Management" )]
    [Description( "Block for viewing a reservation detail" )]
    public partial class ReservationDetail : Rock.Web.UI.RockBlock
    {
        #region Fields

        #endregion

        #region Base Control Methods

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );

            // this event gets fired after block settings are updated. it's nice to repaint the screen if these settings would alter it
            this.AddConfigurationUpdateTrigger( upnlContent );
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Load" /> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );
            if ( !Page.IsPostBack )
            {
                ShowDetail();
            }
        }

        /// <summary>
        /// Returns breadcrumbs specific to the block that should be added to navigation
        /// based on the current page reference.  This function is called during the page's
        /// oninit to load any initial breadcrumbs
        /// </summary>
        /// <param name="pageReference">The page reference.</param>
        /// <returns></returns>
        public override List<BreadCrumb> GetBreadCrumbs( PageReference pageReference )
        {
            var breadCrumbs = new List<BreadCrumb>();

            int? reservationId = PageParameter( pageReference, "ReservationId" ).AsIntegerOrNull();
            if ( reservationId != null )
            {
                Reservation reservation = new ReservationService( new RockContext() ).Get( reservationId.Value );
                if ( reservation != null )
                {
                    breadCrumbs.Add( new BreadCrumb( "Edit Reservation", pageReference ) );
                }
                else
                {
                    breadCrumbs.Add( new BreadCrumb( "New Reservation", pageReference ) );
                }
            }
            else
            {
                // don't show a breadcrumb if we don't have a pageparam to work with
            }

            return breadCrumbs;
        }

        #endregion

        #region Events

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void btnSave_OnClick( object sender, EventArgs e )
        {
            RockContext rockContext = new RockContext();
            ReservationService roomReservationService = new ReservationService( rockContext );
            PersonAliasService personAliasService = new PersonAliasService( rockContext );
            Reservation reservation = null;

            if ( PageParameter( "ReservationId" ).AsIntegerOrNull() != null )
            {
                reservation = roomReservationService.Get( PageParameter( "ReservationId" ).AsInteger() );
            }

            if ( reservation == null )
            {
                reservation = new Reservation { Id = 0 };
            }

            var locationIds = lpLocation.SelectedValuesAsInt();
            foreach ( var locationId in locationIds )
            {
                ReservationLocation reservationLocation = reservation.ReservationLocations.Where( l => l.LocationId == locationId ).FirstOrDefault();
                if ( reservationLocation == null )
                {
                    reservationLocation = new ReservationLocation();
                    reservationLocation.LocationId = locationId;
                    reservationLocation.ReservationId = reservation.Id;
                    reservation.ReservationLocations.Add( reservationLocation );
                }
            }

            var resourceIds = srpResource.SelectedValuesAsInt();
            foreach ( var resourceId in resourceIds )
            {
                ReservationResource reservationResource = reservation.ReservationResources.Where( r => r.ResourceId == resourceId ).FirstOrDefault();
                if ( reservationResource == null )
                {
                    reservationResource = new ReservationResource();
                    reservationResource.ResourceId = resourceId;
                    reservationResource.ReservationId = reservation.Id;
                    reservation.ReservationResources.Add( reservationResource );
                }
            }

            if ( sbSchedule.iCalendarContent != null )
            {
                reservation.Schedule = new Schedule();
                reservation.Schedule.iCalendarContent = sbSchedule.iCalendarContent;
            }

            reservation.RequestorAliasId = CurrentPersonAliasId;

            if ( !reservation.IsApproved && cbIsApproved.Checked )
            {
                reservation.ApproverAliasId = CurrentPersonAliasId;
            }

            if ( ddlCampus.SelectedValueAsId().HasValue )
            {
                reservation.CampusId = ddlCampus.SelectedValueAsId().Value;
            }

            if ( ddlMinistry.SelectedValueAsId().HasValue )
            {
                reservation.MinistryId = ddlMinistry.SelectedValueAsId().Value;
            }

            reservation.IsApproved = cbIsApproved.Checked;
            reservation.Note = rtbNote.Text;
            reservation.Name = rtbName.Text;
            reservation.NumberAttending = nbAttending.Text.AsInteger();
            reservation.SetupTime = nbSetupTime.Text.AsInteger();
            reservation.CleanupTime = nbCleanupTime.Text.AsInteger();

            if ( reservation.Id.Equals( 0 ) )
            {
                roomReservationService.Add( reservation );
            }

            rockContext.SaveChanges();

            ReturnToParentPage();
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void btnCancel_OnClick( object sender, EventArgs e )
        {
            ReturnToParentPage();
        }

        protected void lpLocation_SelectItem( object sender, EventArgs e )
        {

        }

        #endregion

        #region Methods


        private void ShowDetail()
        {
            RockContext rockContext = new RockContext();
            ReservationService roomReservationService = new ReservationService( rockContext );
            Reservation reservation = null;

            if ( PageParameter( "ReservationId" ).AsIntegerOrNull() != null )
            {
                reservation = roomReservationService.Get( PageParameter( "ReservationId" ).AsInteger() );
            }

            if ( reservation == null )
            {
                reservation = new Reservation { Id = 0 };
                if ( PageParameter( "ResourceId" ).AsInteger() != 0 )
                {
                    srpResource.SetValue( PageParameter( "ResourceId" ).AsInteger() );
                }

                if ( PageParameter( "LocationId" ).AsInteger() != 0 )
                {
                    lpLocation.SetValue( PageParameter( "LocationId" ).AsInteger() );
                }
            }

            sbSchedule.iCalendarContent = string.Empty;
            if ( reservation.Schedule != null )
            {
                sbSchedule.iCalendarContent = reservation.Schedule.iCalendarContent;
            }
            else
            {
                if ( PageParameter( "ScheduleId" ).AsInteger() != 0 )
                {
                    var schedule = new ScheduleService( rockContext ).Get( PageParameter( "ScheduleId" ).AsInteger() );
                    if ( schedule != null )
                    {
                        sbSchedule.iCalendarContent = schedule.iCalendarContent;
                    }
                }
            }

            var locationIds = reservation.ReservationLocations.Select( rl => rl.LocationId ).ToList();
            if ( locationIds.Count > 0 )
            {
                lpLocation.SetValues( locationIds );
            }

            var resourceIds = reservation.ReservationResources.Select( rr => rr.ResourceId ).ToList();
            if ( resourceIds.Count > 0 )
            {
                srpResource.SetValues( resourceIds );
            }

            rtbName.Text = reservation.Name;
            cbIsApproved.Checked = reservation.IsApproved;
            rtbNote.Text = reservation.Note;
            nbAttending.Text = reservation.NumberAttending.ToString();
            nbSetupTime.Text = reservation.SetupTime.ToString();
            nbCleanupTime.Text = reservation.CleanupTime.ToString();

            ddlCampus.Items.Clear();
            ddlCampus.Items.Add( new ListItem( string.Empty, string.Empty ) );

            foreach ( var campus in CampusCache.All() )
            {
                ddlCampus.Items.Add( new ListItem( campus.Name, campus.Id.ToString().ToUpper() ) );
            }
            ddlCampus.SetValue( reservation.CampusId );

            ddlMinistry.BindToDefinedType( DefinedTypeCache.Read( com.centralaz.RoomManagement.SystemGuid.DefinedType.MINISTRY.AsGuid() ), true );
            ddlMinistry.SetValue( reservation.MinistryId );

        }

        /// <summary>
        /// Returns the user to the schedule page
        /// </summary>
        protected void ReturnToParentPage()
        {
            Dictionary<string, string> dictionaryInfo = new Dictionary<string, string>();
            dictionaryInfo.Add( "CalendarDate", PageParameter( "CalendarDate" ) );
            NavigateToParentPage( dictionaryInfo );
        }

        #endregion
        protected void rpResource_SelectItem( object sender, EventArgs e )
        {

        }
    }
}