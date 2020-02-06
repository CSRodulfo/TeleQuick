using Business.StockUnificado;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IServices.StockUnifieds
{
    public interface IStockUnifiedService
    {
        Task<List<MedicineAvailableReturn>> Search(IEnumerable<MedicineStock> desiredMedicines);
    }
}
