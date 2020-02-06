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
    public class ImageRestService : BaseRestService, IImageRestService
    {
        private readonly string imageApi;

        public ImageRestService(IOptions<AppOptions> options, HttpRequestBuilder httpRequestBuilder, CustomHttpClient client)
            : base(httpRequestBuilder, client)
        {
            this.imageApi = "https://fcityrepoimagenes.farmacity.net/imagenes/Medicamentos/Imagenes";
        }

        public async Task<byte[]> Get(string id)
        {
            var request = this.httpRequestBuilder.Initialize($"{this.imageApi}/{id}_1.jpg")
                .SetMethod(HttpMethod.Get)
                .Build();

            return await this.client.DoCallBytes(request);
        }
    }
}