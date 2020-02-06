using Business.BranchOffices;
using Business.IRestServices;
using Business.StockUnificado;
using Common.Configuration;
using DataAccess.BuildersRest;
using DataAccess.Commons;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataAccess.RestServices
{
    public class StockUnifiedRestService : BaseRestService, IStockUnifiedRestService
    {
        private readonly string stockUnificadoApiUrl;

        public StockUnifiedRestService(IOptions<AppOptions> options, HttpRequestBuilder httpRequestBuilder, CustomHttpClient client)
            : base(httpRequestBuilder, client)
        {
            this.stockUnificadoApiUrl = $"{options.Value.StockUnificadoApiUrl}StockUnificado";
        }

        public async Task<List<MedicineAvailableResponse>> GetMedicineAvailable(MedicineAvailableRequest medicineAvailaible)
        {
            var request = this.httpRequestBuilder.Initialize($"{this.stockUnificadoApiUrl}/sucursalcufcantidad/")
              .SetBody(medicineAvailaible)
              .SetMethod(HttpMethod.Post)
              .Build();

            return await this.client.DoCall<List<MedicineAvailableResponse>>(request);
        }
    }
}