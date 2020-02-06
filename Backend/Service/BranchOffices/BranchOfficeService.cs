using AutoMapper;
using Business.BranchOffices;
using Business.IRestServices;
using IServices.BranchOffices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.BranchOffices
{
    public class BranchOfficeService : IBranchOfficeService
    {
        private readonly IBranchOfficeRestService branchOfficeRestService;
        private readonly IMapper dtoMapper;

        public BranchOfficeService(IBranchOfficeRestService branchOfficeRestService, IMapper dtoMapper)
        {
            this.branchOfficeRestService = branchOfficeRestService;
            this.dtoMapper = dtoMapper;
        }

        public async Task<List<BranchOfficeLite>> GetAll()
        {
            var result = await this.branchOfficeRestService.GetAll();
            return this.dtoMapper.Map<List<BranchOfficeLite>>(result);
        }

        public async Task<List<BranchOfficeLite>> GetAll(IEnumerable<int> services)
        {
            var result = await this.branchOfficeRestService.GetAll(services);
            return this.dtoMapper.Map<List<BranchOfficeLite>>(result);
        }

        public async Task<List<BranchOfficeLite>> GetAllWithMedicineReservation()
        {
            return await this.GetAll(new List<int> { 9 });
        }

        public async Task<BranchOfficeLite> GetById(int id)
        {
            var a = await this.branchOfficeRestService.GetById(id);
            return this.dtoMapper.Map<BranchOfficeLite>(a);
        }

        public async Task<BranchOffice> GetBranchOfficeById(int id)
        {
            var a = await this.branchOfficeRestService.GetBranchOfficeById(id);
            return this.dtoMapper.Map<BranchOffice>(a);
        }
    }
}
