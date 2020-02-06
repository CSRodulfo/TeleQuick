using Business.IRestServices;
using Business.Parameters;
using Common.Configuration;
using DataAccess.BuildersRest;
using DataAccess.Commons;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RestServices
{
    public class ParametersRestService : BaseRestService, IParametersRestService
    {
        private readonly string parametersApi;
        public ParametersRestService(IOptions<AppOptions> options, HttpRequestBuilder httpRequestBuilder, CustomHttpClient client) : base(httpRequestBuilder, client)
        {

            this.parametersApi = $"{options.Value.FcdmApi}Parameters";
        }

        public async Task<IEnumerable<OptIn>> GetOptines()
        {

            var request = this.httpRequestBuilder.Initialize($"{this.parametersApi}/optIns")
                         .SetMethod(HttpMethod.Get)
                         .Build();

            return await this.client.DoCall<IEnumerable<OptIn>>(request);
        }

        public async Task<IEnumerable<Province>> GetProvinces()
        {
            var request = this.httpRequestBuilder.Initialize($"{this.parametersApi}/provinces")
                          .SetMethod(HttpMethod.Get)
                          .Build();

            return await this.client.DoCall<IEnumerable<Province>>(request);
        }
    }
}
