using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Reservations
{
    public class ReserveRequest : Token
    {
        public int IdSucursal { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string SucursalName { get; set; }
        public IEnumerable<ReserveItemRequest> Items { get; set; }
    }
}
