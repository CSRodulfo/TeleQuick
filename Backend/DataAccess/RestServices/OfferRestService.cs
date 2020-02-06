using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Business.IRestServices;
using Business.Offers;
using Common.Configuration;
using DataAccess.BuildersRest;
using DataAccess.Commons;
using Microsoft.Extensions.Options;

namespace DataAccess.RestServices
{
    public class OfferRestService : BaseRestService, IOfferRestService
    {
        private readonly string offerApi;

        public OfferRestService(IOptions<AppOptions> options, HttpRequestBuilder httpRequestBuilder, CustomHttpClient client)
            : base(httpRequestBuilder, client)
        {
            this.offerApi = $"{options.Value.MicroServicesApiUrl}offer";
        }

        public async Task<IEnumerable<CategoriaResponse>> GetAllCategories()
        {
            var request = this.httpRequestBuilder.Initialize($"{this.offerApi}/GetAllCategories")
                .SetMethod(HttpMethod.Get)
                .Build();

            return await this.client.DoCall<IEnumerable<CategoriaResponse>>(request);
        }

        public async Task<IEnumerable<PromocionResponse>> GetAllOffs()
        {
            var request = this.httpRequestBuilder.Initialize($"{this.offerApi}/GetAllOffs")
                .SetMethod(HttpMethod.Get)
                .Build();

            return await this.client.DoCall<IEnumerable<PromocionResponse>>(request);
        }

        public async Task<IEnumerable<OfertaClienteResponse>> GetAllOffClient()
        {
            var request = this.httpRequestBuilder.Initialize($"{this.offerApi}/GetAllOffClient")
                .SetMethod(HttpMethod.Get)
                .Build();

            return await this.client.DoCall<IEnumerable<OfertaClienteResponse>>(request);
        }


        public async Task<IEnumerable<OfertaClienteResponse>> GetByKeyClient(string keyClient)
        {
            var request = this.httpRequestBuilder.Initialize($"{this.offerApi}/GetByKeyClient")
                .SetQueryParameter("keyClient", keyClient)
                .SetMethod(HttpMethod.Get)
                .Build();

            return await this.client.DoCall<IEnumerable<OfertaClienteResponse>>(request);
        }

    }
}
