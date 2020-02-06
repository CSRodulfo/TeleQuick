using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Offers;
using IServices.Offers;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : Controller
    {
        private readonly IOfferService offerService;

        public OfferController(IOfferService offerService)
        {
            this.offerService = offerService;
        }

        [HttpGet("GetAllCategories")]
        public async Task<IEnumerable<CategoriaResponse>> GetAllCategories()
        {
            return await this.offerService.GetAllCategories();
        }

        [HttpGet("GetAllOffs")]
        public async Task<IEnumerable<PromocionResponse>> GetAllOffs()
        {
            return await this.offerService.GetAllOffs();
        }

        [HttpGet("GetAllOffClient")]
        public async Task<IEnumerable<OfertaClienteResponse>> GetAllOffClient()
        {
            return await this.offerService.GetAllOffClient();
        }

        [HttpGet("GetByKeyClient    ")]
        public async Task<IEnumerable<OfertaClienteResponse>> GetByKeyClient(string keyClient)
        {
            return await this.offerService.GetByKeyClient(keyClient);
        }
    }
}