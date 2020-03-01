// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using TeleQuick.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using IDataAccess.Repositories;

namespace TeleQuick.IDataAccess.Business
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        new Task<IEnumerable<Vehicle>> GetAll();

        Task<Vehicle> GetByIdAll(int id);

    }
}