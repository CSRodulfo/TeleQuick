using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Reservations
{
    public class ReserveItemRequest
    {
        public int CUF { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }
    }
}
