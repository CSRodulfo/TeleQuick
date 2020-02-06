using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.IRestServices;
using Business.StockUnificado;
using IServices.StockUnifieds;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockUnifiedController : Controller
    {
        private readonly IStockUnifiedService stockUnifiedService;

        public StockUnifiedController(IStockUnifiedService stockUnifiedService)
        {
            this.stockUnifiedService = stockUnifiedService;
        }

        [HttpPost("search")]
        public async Task<List<MedicineAvailableReturn>> Search([FromBody]IEnumerable<MedicineStock> search)
        {
            return await this.stockUnifiedService.Search(search);
        }
    }
}