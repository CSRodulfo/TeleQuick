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
        public async Task<IEnumerable<Vehicle>> GetAll()
        {
            return await _unitOfWork.Vehicles.GetAll();
        }

        public async Task<int> Create(Vehicle vehicle)
        {
            _unitOfWork.Vehicles.Add(vehicle);
            return _unitOfWork.SaveChanges();
        }

        public async Task<int> Update(Vehicle vehicle)
        {
            _unitOfWork.Vehicles.Update(vehicle);
            return _unitOfWork.SaveChanges();
        }

        public async Task<Vehicle> GetById(int id)
        {
            return await _unitOfWork.Vehicles.GetById(id);
        }
    }
}