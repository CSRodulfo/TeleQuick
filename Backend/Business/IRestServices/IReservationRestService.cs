using Business.BranchOffices;
using Business.Common;
using Business.Reservations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.IRestServices
{
    public interface IReservationRestService
    {
        Task<IList<Reserve>> Reservations(Token token);
        Task<ReserveResponse> Reserve(ReserveRequest reserve);
        Task CancelReserve(CancelReserve reserve);
    }
}
