using Business.BranchOffices;
using Business.IRestServices;
using Business.Medicines;
using Common.Configuration;
using DataAccess.BuildersRest;
using DataAccess.Commons;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataAccess.RestServices
{
    public class MedicineRestService : BaseRestService, IMedicineRestService
    {
        private readonly string medicineApi;

        public MedicineRestService(IOptions<AppOptions> options, HttpRequestBuilder httpRequestBuilder, CustomHttpClient client)
            : base(httpRequestBuilder, client)
        {
            this.medicineApi = $"{options.Value.MicroServicesApiUrl}medicine";
        }

        public async Task<IEnumerable<Item>> Search(string filter)
        {
            var request = this.httpRequestBuilder.Initialize($"{this.medicineApi}/search")
                .SetQueryParameter("filter", filter)
                .SetMethod(HttpMethod.Get)
                .Build();

            return await this.client.DoCall<IEnumerable<Item>>(request);
        }

        public async Task<IEnumerable<Item>> GetAllByDescription(string description)
        {
            var request = this.httpRequestBuilder.Initialize($"{this.medicineApi}/searchByDescription")
                .SetQueryParameter("description", description)
                .SetMethod(HttpMethod.Get)
                .Build();

            return await this.client.DoCall<IEnumerable<Item>>(request);
        }

        public async Task<IEnumerable<Item>> GetByFormula(int idFormula, string potency, int unitPotencyId, int packageDescriptionId)
        {
            var request = this.httpRequestBuilder.Initialize($"{this.medicineApi}/searchRelationMedicine")
                .SetQueryParameter("idFormula", idFormula.ToString())
                .SetQueryParameter("potency", potency.ToString())
                .SetQueryParameter("unitPotencyId", unitPotencyId.ToString())
                .SetQueryParameter("packageDescriptionId", packageDescriptionId.ToString())
                .SetMethod(HttpMethod.Get)
                .Build();

            return await this.client.DoCall<IEnumerable<Item>>(request);
        }
    }
}