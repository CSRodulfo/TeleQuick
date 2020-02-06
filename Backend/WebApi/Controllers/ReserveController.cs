using Business.MedicalInsurances;
using Business.Medicines;
using Business.Reservations;
using IServices.MedicalInsurances;
using IServices.Medicines;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReserveController : Controller
    {
        private readonly IReservationService reservationService;

        public ReserveController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }

        [HttpPost("user-reservations")]
        public async Task<IList<Reserve>> Reservations(Token token)
        {
            return await this.reservationService.Reservations(token);
        }


        [HttpPost("reserve")]
        public async Task<ReserveResponse> Reserve(ReserveRequest reserve)
        {
            return await this.reservationService.Reserve(reserve);
        }

        [HttpPost("cancelreserve")]
        public async Task CancelReserve(CancelReserve reserve)
        {
            await this.reservationService.CancelReserve(reserve);
        }
    }
}
