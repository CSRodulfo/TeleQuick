using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccess.BuildersRest
{
    public class HttpRequestBuilder
    {
        private HttpRequestMessage request;

        private StringBuilder urlStringBuilder;
        private string QueryParameters { get; set; }
        public HttpRequestBuilder()
        {
        }

        public HttpRequestBuilder Initialize(string url)
        {
            this.request = new HttpRequestMessage(HttpMethod.Get, url);
            this.urlStringBuilder = new StringBuilder(url);
            this.QueryParameters = string.Empty;
            return this;
        }

        public HttpRequestBuilder SetMethod(HttpMethod method)
        {
            this.request.Method = method;
            return this;
        }

        public HttpRequestBuilder SetQueryParameter(string key, string value)
        {
            string queryString;
            if (string.IsNullOrEmpty(this.QueryParameters))
            {
                var encodedValue = HttpUtility.UrlEncode(value);
                queryString = string.Format("?{0}={1}", key, encodedValue);
            }
            else
            {
                var encodedValue = HttpUtility.UrlEncode(value);
                queryString = string.Format("&{0}={1}", key, encodedValue);
            }

            this.QueryParameters = string.Concat(this.QueryParameters, queryString);

            return this;
        }

        public HttpRequestBuilder SetBody(object data)
        {
            this.request.Content = this.SerializeObjectToJson(data);
            return this;
        }

        public HttpRequestMessage Build()
        {
            this.urlStringBuilder.Append(this.QueryParameters);

            var url = this.urlStringBuilder.ToString();
            this.request.RequestUri = new Uri(url);
            return this.request;
        }

        protected StringContent SerializeObjectToJson(object objectToSerialize)
        {
            var json = JsonConvert.SerializeObject(objectToSerialize);
            var httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return httpContent;
        }

        private string GetUrl(string url, object parameters)
        {
            var query = this.GetQueryString(parameters);
            return url + query;
        }

        private string GetQueryString(object obj)
        {
            if (string.IsNullOrEmpty(obj.ToString()))
            {
                return string.Empty;
            }

            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name.ToLower() + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            var queryString = string.Join("&", properties.ToArray());
            return "?" + queryString;
        }
    }
}
