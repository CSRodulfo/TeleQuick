using Business.Medicines;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Medicines
{
    public interface IMedicineService
    {
        Task<IEnumerable<Item>> Search(string filter);
        Task<IEnumerable<Item>> GetAllByDescription(string description);
        Task<IEnumerable<Item>> GetByFormula(int idFormula, string potency, int unitPotencyId, int packageDescriptionId);
    }
}
