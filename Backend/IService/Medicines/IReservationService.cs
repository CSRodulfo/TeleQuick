using Business.Medicines;
using Business.Reservations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Medicines
{
    public interface IReservationService
    {
        Task<ReserveResponse> Reserve(ReserveRequest reserve);
        Task CancelReserve(CancelReserve reserve);
        Task<IList<Reserve>> Reservations(Token token);
    }
}
