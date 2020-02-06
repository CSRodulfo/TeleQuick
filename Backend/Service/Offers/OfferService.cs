using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.IRestServices;
using Business.Offers;
using IServices.Offers;

namespace Services.Offers
{

    public class OfferService : IOfferService
    {
        private readonly IOfferRestService OfferRestService;

        public OfferService(IOfferRestService OfferRestService)
        {
            this.OfferRestService = OfferRestService;
        }

        public Task<IEnumerable<CategoriaResponse>> GetAllCategories()
        {
            return this.OfferRestService.GetAllCategories();
        }

        public Task<IEnumerable<PromocionResponse>> GetAllOffs()
        {
            return this.OfferRestService.GetAllOffs();
        }

        public Task<IEnumerable<OfertaClienteResponse>> GetAllOffClient()
        {
            return this.OfferRestService.GetAllOffClient();
        }
        public Task<IEnumerable<OfertaClienteResponse>> GetByKeyClient(string keyClient)
        {
            return this.OfferRestService.GetByKeyClient(keyClient);
        }
    }
}
