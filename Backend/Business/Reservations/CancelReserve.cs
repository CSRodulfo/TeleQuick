using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Reservations
{
    public class CancelReserve : Token
    {
        public string ReservationKey { get; set; }
    }
}
