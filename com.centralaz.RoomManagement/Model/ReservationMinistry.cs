using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Runtime.Serialization;

namespace com.centralaz.RoomManagement.Model
{
    /// <summary>
    /// A Reservation Ministry
    /// </summary>
    [Table( "_com_centralaz_RoomManagement_ReservationMinistry" )]
    [DataContract]
    public class ReservationMinistry : Rock.Data.Model<ReservationMinistry>, Rock.Data.IRockEntity
    {

        #region Entity Properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        [DataMember]
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
        private bool _isActive = true;

        #endregion

    }

    #region Entity Configuration


    public partial class ReservationMinistryConfiguration : EntityTypeConfiguration<ReservationMinistry>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationMinistryConfiguration"/> class.
        /// </summary>
        public ReservationMinistryConfiguration()
        {

        }
    }

    #endregion

}
