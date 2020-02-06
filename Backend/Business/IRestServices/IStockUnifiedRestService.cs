using Business.StockUnificado;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.IRestServices
{
    public interface IStockUnifiedRestService
    {
        Task<List<MedicineAvailableResponse>> GetMedicineAvailable(MedicineAvailableRequest medicineAvailaible);
    }
}
