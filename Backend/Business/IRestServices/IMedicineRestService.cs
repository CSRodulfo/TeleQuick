using Business.BranchOffices;
using Business.Common;
using Business.Medicines;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.IRestServices
{
    public interface IMedicineRestService
    {
        Task<IEnumerable<Item>> Search(string filter);
        Task<IEnumerable<Item>> GetAllByDescription(string description);
        Task<IEnumerable<Item>> GetByFormula(int idFormula, string potency, int unitPotencyId, int packageDescriptionId);
    }
}
