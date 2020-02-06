using Business.IRestServices;
using Business.MedicalInsurances;
using Business.Medicines;
using Business.Reservations;
using IServices.MedicalInsurances;
using IServices.Medicines;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Medicines
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRestService reservationRestService;

        public ReservationService(IReservationRestService reserveRestService)
        {
            this.reservationRestService = reserveRestService;
        }

        public async Task<IList<Reserve>> Reservations(Token token)
        {
            return await this.reservationRestService.Reservations(token);
        }

        public async Task<ReserveResponse> Reserve(ReserveRequest reserve)
        {
            return await this.reservationRestService.Reserve(reserve);
        }

        public async Task CancelReserve(CancelReserve reserve)
        {
            await this.reservationRestService.CancelReserve(reserve);
        }
    }
}
