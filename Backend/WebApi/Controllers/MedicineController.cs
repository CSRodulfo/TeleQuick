using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Medicines;
using IServices.Medicines;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : Controller
    {
        private readonly IMedicineService medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            this.medicineService = medicineService;
        }

        [HttpGet("search")]
        public async Task<IEnumerable<Item>> Search(string filter)
        {
            return await this.medicineService.Search(filter);
        }

        [HttpGet("searchByFormula")]
        public async Task<IEnumerable<Item>> GetByFormula(int idFormula, string potency, int unitPotencyId, int packageDescriptionId)
        {
            return await this.medicineService.GetByFormula(idFormula, potency, unitPotencyId, packageDescriptionId);
        }
    }
}
