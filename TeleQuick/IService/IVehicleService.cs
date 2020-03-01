using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Business.Models;

namespace TeleQuick.IService
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetAll();
        Task<int> Create(Vehicle vehicle);
        Task<int> Update(Vehicle vehicle);
        Task<Vehicle> GetById(int id);
    }
}
