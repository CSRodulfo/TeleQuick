using Business.BranchOffices;
using Business.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IServices.BranchOffices
{
    public interface IServiceService
    {
        Task<List<Service>> GetAll();
    }
}
