using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataAccess.Commons
{
    public class CustomHttpClient
    {
        private readonly HttpClient httpClient;
        public CustomHttpClient()
        {
            this.httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(20),
            };
        }

        public async Task<T> DoCall<T>(HttpRequestMessage request , string token = null)
            where T : class
        {
            return await this.DoCallGeneric<T>(request, this.ValidateHttpRespose, token);
        }

        public async Task DoCall(HttpRequestMessage request, string token = null)
        {
            await this.DoCallGeneric(request, this.ValidateHttpRespose, token);
        }

        public async Task DoCallFcdmResetToken(HttpRequestMessage request)
        {
            await this.DoCallGeneric(request, this.ValidateHttpResposeFcdmResetPassword);
        }


        private async Task DoCallGeneric(HttpRequestMessage request, Func<HttpResponseMessage, Task> validateHttpResponseAction, string token = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(token))
                    this.httpClient.SetBearerToken(token);

                var response = await this.httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    await validateHttpResponseAction.Invoke(response);

                }
                var result = await response.Content.ReadAsStringAsync();
            }
            catch (TaskCanceledException)
            {
                throw new TimeoutException();
            }
            catch (HttpRequestException)
            {
                throw new NoConnectionException();
            }
        }


        private async Task<T> DoCallGeneric<T>(HttpRequestMessage request, Func<HttpResponseMessage, Task> validateHttpResponseAction, string token = null)
            where T : class
        {
            try
            {
                if (!string.IsNullOrEmpty(token))
                    this.httpClient.SetBearerToken(token);

                var response = await this.httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    await validateHttpResponseAction.Invoke(response);
                    return null;
                }

                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(result);
            }
            catch (TaskCanceledException)
            {
                throw new TimeoutException();
            }
            catch (HttpRequestException)
            {
                throw new NoConnectionException();
            }
        }

        public async Task<byte[]> DoCallBytes(HttpRequestMessage request)
        {
            try
            {
                var response = await this.httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                return await response.Content.ReadAsByteArrayAsync();
            }
            catch (TaskCanceledException)
            {
                throw new TimeoutException();
            }
            catch (HttpRequestException)
            {
                throw new NoConnectionException();
            }
        }

        private async Task ValidateHttpRespose(HttpResponseMessage res)
        {
            switch (res.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    throw new ClientException(res.StatusCode, "Recurso no encontrado");

                case HttpStatusCode.Unauthorized:
                    throw new ClientException(res.StatusCode, "Solicitud no autorizada");

                case HttpStatusCode.BadRequest:
                    var badRequesttResponse = await res.Content.ReadAsStringAsync();
                    var badRequestErrorResult = JsonConvert.DeserializeObject<BaseResponse>(badRequesttResponse);
                    throw new ClientException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, badRequestErrorResult.Errors), badRequestErrorResult.ErrorCode);

                case HttpStatusCode.InternalServerError:
                    var inetrnalServerErrorResponse = await res.Content.ReadAsStringAsync();
                    var internalServerErrorResult = JsonConvert.DeserializeObject<BaseResponse>(inetrnalServerErrorResponse);
                    throw new ClientException(HttpStatusCode.InternalServerError, string.Join(Environment.NewLine, internalServerErrorResult.Errors), internalServerErrorResult.ErrorCode);

                default:
                    throw new ClientException(res.StatusCode, "Error de conexion no detectado");
            }
        }

        private async Task ValidateHttpResposeFcdmResetPassword(HttpResponseMessage res)
        {
            switch (res.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    throw new ClientException(HttpStatusCode.BadRequest, "¡No pudimos encontrar el correo electrónico ingresado! Volvé a intentar con otro.");
            }

            await this.ValidateHttpRespose(res);
        }
    }
}
