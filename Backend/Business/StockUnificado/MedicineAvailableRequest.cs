using System.Collections.Generic;

namespace Business.StockUnificado
{
    public class MedicineAvailableRequest
    {
        public List<int> SucursalList { get; set; }
        public List<MedicineStock> CufCantidadList { get; set; }
    }
}
