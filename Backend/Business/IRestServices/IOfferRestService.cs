
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Offers;

namespace Business.IRestServices
{
    public interface IOfferRestService
    {
        Task<IEnumerable<CategoriaResponse>> GetAllCategories();
        Task<IEnumerable<PromocionResponse>> GetAllOffs();
        Task<IEnumerable<OfertaClienteResponse>> GetAllOffClient();
        Task<IEnumerable<OfertaClienteResponse>> GetByKeyClient(string keyClient);
    }
}
