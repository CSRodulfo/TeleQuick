// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDataAccess.Repositories
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        new Task<IEnumerable<Vehicle>> GetAll();

    }
}