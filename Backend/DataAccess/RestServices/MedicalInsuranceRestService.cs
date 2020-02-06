using Business.IRestServices;
using Business.MedicalInsurances;
using Common.Configuration;
using DataAccess.BuildersRest;
using DataAccess.Commons;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataAccess.RestServices
{
    public class MedicalInsuranceRestService : BaseRestService, IMedicalInsuranceRestService
    {
        private readonly string medicalInsuranceApi;

        public MedicalInsuranceRestService(IOptions<AppOptions> options, HttpRequestBuilder httpRequestBuilder, CustomHttpClient client)
            : base(httpRequestBuilder, client)
        {
            this.medicalInsuranceApi = $"{options.Value.MicroServicesApiUrl}MedicalInsurance";
        }

        public async Task<List<MedicalInsurance>> GetAll()
        {
            var request = this.httpRequestBuilder.Initialize(this.medicalInsuranceApi)
               .SetMethod(HttpMethod.Get)
               .Build();

            return await this.client.DoCall<List<MedicalInsurance>>(request);
        }
    }
}
