using Business.BranchOffices;
using Business.IRestServices;
using Common.Configuration;
using DataAccess.BuildersRest;
using DataAccess.Commons;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataAccess.RestServices
{
    public class BranchOfficeRestService : BaseRestService, IBranchOfficeRestService
    {
        private readonly string branchOfficeApi;

        public BranchOfficeRestService(IOptions<AppOptions> options, HttpRequestBuilder httpRequestBuilder, CustomHttpClient client)
            : base(httpRequestBuilder, client)
        {
            this.branchOfficeApi = $"{options.Value.MicroServicesApiUrl}BranchOffice";
        }

        public async Task<BranchOfficeMicroServiceLite> GetBranchOfficeById(int id)
        {
            var request = this.httpRequestBuilder.Initialize($"{this.branchOfficeApi}//{id}")
              .SetMethod(HttpMethod.Get)
              .Build();

            return await this.client.DoCall<BranchOfficeMicroServiceLite>(request);
        }

        public async Task<List<BranchOfficeMicroService>> GetAll()
        {
            var request = this.httpRequestBuilder.Initialize(this.branchOfficeApi)
              .SetMethod(HttpMethod.Get)
              .Build();

            return await this.client.DoCall<List<BranchOfficeMicroService>>(request);
        }

        public async Task<List<BranchOfficeMicroService>> GetAll(IEnumerable<int> services)
        {
            var body = new
            {
                services = services,
            };

            var request = this.httpRequestBuilder.Initialize($"{this.branchOfficeApi}/search")
                .SetBody(body)
                .SetMethod(HttpMethod.Post)
                .Build();

            return await this.client.DoCall<List<BranchOfficeMicroService>>(request);
        }

        public async Task<BranchOfficeMicroService> GetById(int id)
        {
            var request = this.httpRequestBuilder.Initialize(this.branchOfficeApi)
            .SetMethod(HttpMethod.Get)
            .Build();

            return await this.client.DoCall<BranchOfficeMicroService>(request);
        }
    }
}