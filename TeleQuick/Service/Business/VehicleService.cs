using Business.Business;
using IDataAccess;
using IService.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Business
{
    public class VehicleService :   IVehicleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehicleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/values
        public IEnumerable<Vehicle> Get()
        {
            var allCustomers = _unitOfWork.Vehicles.GetAllVehiclesData();
            return allCustomers;
        }
    }
}
