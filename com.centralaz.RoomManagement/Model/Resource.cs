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
    /// A Room Resource
    /// </summary>
    [Table( "_com_centralaz_RoomManagement_Resource" )]
    [DataContract]
    public class Resource : Rock.Data.Model<Resource>, Rock.Data.IRockEntity, Rock.Data.ICategorized
    {

        #region Entity Properties

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int? CategoryId { get; set; }

        [DataMember]
        public int? CampusId { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public string Note { get; set; }

        #endregion

        #region Virtual Properties

        public virtual Category Category { get; set; }

        public virtual Campus Campus { get; set; }

        #endregion

    }

    #region Entity Configuration


    public partial class ResourceConfiguration : EntityTypeConfiguration<Resource>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceConfiguration"/> class.
        /// </summary>
        public ResourceConfiguration()
        {
            this.HasRequired( r => r.Category ).WithMany().HasForeignKey( r => r.CategoryId ).WillCascadeOnDelete( false );
            this.HasOptional( r => r.Campus ).WithMany().HasForeignKey( r => r.CampusId ).WillCascadeOnDelete( false );
        }
    }

    #endregion

}
