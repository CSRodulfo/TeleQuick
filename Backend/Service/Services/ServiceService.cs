using AutoMapper;
using Business.BranchOffices;
using Business.Common;
using Business.IRestServices;
using IServices.BranchOffices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.BranchOffices
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRestService serviceRestService;
        private readonly IMapper dtoMapper;

        public ServiceService(IServiceRestService serviceRestService, IMapper dtoMapper)
        {
            this.serviceRestService = serviceRestService;
            this.dtoMapper = dtoMapper;
        }

        public async Task<List<Service>> GetAll()
        {
            var a = await this.serviceRestService.GetAll();
            return this.dtoMapper.Map<List<Service>>(a);
        }
    }
}
