using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IService.Business
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetAll();
        Task<int> Create(Vehicle vehicle);
        Task<int> Update(Vehicle vehicle);
        Task<Vehicle> GetById(int id);
    }
}
