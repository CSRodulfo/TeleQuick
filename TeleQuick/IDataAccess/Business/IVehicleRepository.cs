using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Business.Models;
using TeleQuick.IDataAccess.Repositories;

namespace TeleQuick.IDataAccess.Business
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        new Task<IEnumerable<Vehicle>> GetAll();

        Task<Vehicle> GetByIdAll(int id);
    }
}