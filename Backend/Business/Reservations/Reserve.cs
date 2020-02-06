using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Reservations
{
    public class Reserve
    {
        public string Key { get; set; }
        public string ReservationNumber { get; set; }
        public string FcdmUserKey { get; set; }
        public int IdSucursal { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Expiration { get; set; }
        public string IdStockReservation { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
        public string DeliveryNote { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<ReserveItem> Items { get; set; }
    }
}
