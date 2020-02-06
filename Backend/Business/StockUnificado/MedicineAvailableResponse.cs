using System;
using System.Collections.Generic;
using System.Text;

namespace Business.StockUnificado
{
    public class MedicineAvailableResponse
    {
        public int Sucursal { get; set; }
        public int Cuf { get; set; }
        public int Cantidad { get; set; }
    }
}
