using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Reservations
{
    public class ReserveResponse
    {
        public string ReservationKey { get; set; }
        public string ReservationNumber { get; set; }
        public string Status { get; set; }
        public DateTime ReservationDate { get; set; }
        public IEnumerable<ReserveItemResponse> ReservedItems { get; set; }
        public IEnumerable<ReserveItemResponse> UnableToReserve { get; set; }
        public bool AllReserved { get; set; }
    }
}
