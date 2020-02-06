using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Offers;

namespace IServices.Offers
{
    public interface IOfferService
    {
        Task<IEnumerable<CategoriaResponse>> GetAllCategories();
        Task<IEnumerable<PromocionResponse>> GetAllOffs();
        Task<IEnumerable<OfertaClienteResponse>> GetAllOffClient();
        Task<IEnumerable<OfertaClienteResponse>> GetByKeyClient(string keyClient);

    }
}
