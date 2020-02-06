using Business.BranchOffices;
using IServices.BranchOffices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchOfficeController : Controller
    {
        private readonly IBranchOfficeService branchOfficeService;

        public BranchOfficeController(IBranchOfficeService branchOfficeService)
        {
            this.branchOfficeService = branchOfficeService;
        }

        [HttpGet]
        public async Task<IEnumerable<BranchOfficeLite>> GetAll()
        {
            return await this.branchOfficeService.GetAll();
        }

        [HttpGet("medicineReservation")]
        public async Task<IEnumerable<BranchOfficeLite>> GetAllWithMedicineReservation()
        {
            return await this.branchOfficeService.GetAllWithMedicineReservation();
        }

        [HttpPost("search")]
        public async Task<IEnumerable<BranchOfficeLite>> GetAll(BranchOfficeSearchModel model)
        {
            return await this.branchOfficeService.GetAll(model.Services);
        }

        [HttpGet("{id}")]
        public async Task<BranchOffice> GetById(int id)
        {
            return await this.branchOfficeService.GetBranchOfficeById(id);
        }
    }
}
