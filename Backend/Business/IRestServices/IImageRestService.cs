using Business.BranchOffices;
using Business.Common;
using Business.Medicines;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.IRestServices
{
    public interface IImageRestService
    {
        Task<byte[]> Get(string id);
    }
}
