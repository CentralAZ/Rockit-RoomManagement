using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.centralaz.RoomManagement.SystemGuid
{
    public static class ReservationStatus
    {
        /// <summary>
        /// A denied reservation
        /// </summary>
        public const string DENIED = "79A4347E-C399-403A-9053-8FB836354D77";

        /// <summary>
        /// An approved reservation
        /// </summary>
        public const string APPROVED = "D11163C8-4684-471F-9043-E976C75091E8";

        /// <summary>
        /// A pending reservation
        /// </summary>
        public const string NEEDS_APPROVAL = "E739F883-8B84-4755-92C0-3DB6606381F1";
    }
}
