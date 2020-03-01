using IService.TeleQuick.Business;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Business.Models;
using TeleQuick.IDataAccess.Business;

namespace Service.TeleQuick.Business
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        // GET: api/values
        public async Task<IEnumerable<Vehicle>> GetAll()
        {
            return await _vehicleRepository.GetAll();
        }

        public async Task<int> Create(Vehicle vehicle)
        {
            return await _vehicleRepository.Add(vehicle);

        }

        public async Task<int> Update(Vehicle vehicle)
        {
            return await _vehicleRepository.Update(vehicle);
        }

        public async Task<Vehicle> GetById(int id)
        {
            return await _vehicleRepository.GetByIdAll(id);
        }
    }
}