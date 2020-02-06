using Business.BranchOffices;
using Business.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.IRestServices
{
    public interface IBranchOfficeRestService
    {
        Task<List<BranchOfficeMicroService>> GetAll();
        Task<List<BranchOfficeMicroService>> GetAll(IEnumerable<int> services);
        Task<BranchOfficeMicroService> GetById(int id);
        Task<BranchOfficeMicroServiceLite> GetBranchOfficeById(int userId);
       }
}
