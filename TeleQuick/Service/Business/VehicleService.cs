using Business.Models;
using IDataAccess;
using IService.Business;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Business
{
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehicleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/values
        public async Task<IEnumerable<Vehicle>> Get()
        {
            var allCustomers = _unitOfWork.Vehicles.GetAllVehiclesData();
            return await allCustomers;
        }
    }
}
