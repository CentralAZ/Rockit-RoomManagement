﻿using System;
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
    /// A Room Resource
    /// </summary>
    [Table( "_com_centralaz_RoomManagement_ReservationResource" )]
    [DataContract]
    public class ReservationResource : Rock.Data.Model<ReservationResource>, Rock.Data.IRockEntity
    {

        #region Entity Properties
        [Required]
        [DataMember]
        public int ReservationId { get; set; }

        [Required]
        [DataMember]
        public int ResourceId { get; set; }

        [Required]
        [DataMember]
        public int Quantity { get; set; }

        [Required]
        [DataMember]
        public bool IsApproved { get; set; }

        #endregion

        #region Virtual Properties

        public virtual Reservation Reservation { get; set; }

        public virtual Resource Resource { get; set; }

        public void CopyPropertiesFrom( ReservationResource source )
        {
            this.Id = source.Id;
            this.ForeignGuid = source.ForeignGuid;
            this.ForeignKey = source.ForeignKey;
            this.ReservationId = source.ReservationId;
            this.ResourceId = source.ResourceId;
            this.Quantity = source.Quantity;
            this.IsApproved = source.IsApproved;
            this.CreatedDateTime = source.CreatedDateTime;
            this.ModifiedDateTime = source.ModifiedDateTime;
            this.CreatedByPersonAliasId = source.CreatedByPersonAliasId;
            this.ModifiedByPersonAliasId = source.ModifiedByPersonAliasId;
            this.Guid = source.Guid;
            this.ForeignId = source.ForeignId;
        }

        #endregion

    }

    #region Entity Configuration


    public partial class ReservationResourceConfiguration : EntityTypeConfiguration<ReservationResource>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationResourceConfiguration"/> class.
        /// </summary>
        public ReservationResourceConfiguration()
        {
            this.HasRequired( r => r.Reservation ).WithMany( r => r.ReservationResources ).HasForeignKey( r => r.ReservationId ).WillCascadeOnDelete( true );
            this.HasRequired( r => r.Resource ).WithMany().HasForeignKey( r => r.ResourceId ).WillCascadeOnDelete( true );
        }
    }

    #endregion

}
