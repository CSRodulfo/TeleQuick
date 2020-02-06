using Business.BranchOffices;
using Business.IRestServices;
using Business.Reservations;
using Common.Configuration;
using DataAccess.BuildersRest;
using DataAccess.Commons;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataAccess.RestServices
{
    public class ReservationRestService : BaseRestService, IReservationRestService
    {
        private readonly string reserveApi;

        public ReservationRestService(IOptions<AppOptions> options, HttpRequestBuilder httpRequestBuilder, CustomHttpClient client)
            : base(httpRequestBuilder, client)
        {
            this.reserveApi = $"{options.Value.ReservasApiUrl}reservation";
        }

        public async Task<IList<Reserve>> Reservations(Token token)
        {
            var request = this.httpRequestBuilder.Initialize($"{this.reserveApi}/user-reservations")
                .SetMethod(HttpMethod.Get)
                .Build();

            return await this.client.DoCall<IList<Reserve>>(request, token.TokenValue);
        }

        public async Task<ReserveResponse> Reserve(ReserveRequest reserve)
        {
            var request = this.httpRequestBuilder.Initialize($"{this.reserveApi}")
                .SetBody(reserve)
                .SetMethod(HttpMethod.Post)
                .Build();

            return await this.client.DoCall<ReserveResponse>(request, reserve.TokenValue);
        }

        public async Task CancelReserve(CancelReserve reserve)
        {
            var request = this.httpRequestBuilder.Initialize($"{this.reserveApi}/cancel-user")
                .SetBody(new { reservationKey = reserve.ReservationKey })
                .SetMethod(HttpMethod.Post)
                .Build();

            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", reserve.TokenValue);

            await this.client.DoCall<object>(request);
        }
    }
}