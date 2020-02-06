using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Threading.Tasks;
using DataAccess.BuildersRest;
using Newtonsoft.Json;

namespace DataAccess.Commons
{
    public class BaseRestService
    {
        protected readonly HttpRequestBuilder httpRequestBuilder;
        protected readonly CustomHttpClient client;

        public BaseRestService(HttpRequestBuilder httpRequestBuilder, CustomHttpClient client)
        {
            this.httpRequestBuilder = httpRequestBuilder;
            this.client = client;
        }
    }
}
