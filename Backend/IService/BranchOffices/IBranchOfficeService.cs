using Business.BranchOffices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IServices.BranchOffices
{
    public interface IBranchOfficeService
    {
        Task<List<BranchOfficeLite>> GetAll();
        Task<List<BranchOfficeLite>> GetAll(IEnumerable<int> services);
        Task<List<BranchOfficeLite>> GetAllWithMedicineReservation();

        Task<BranchOfficeLite> GetById(int id);

        Task<BranchOffice> GetBranchOfficeById(int id);
    }
}
