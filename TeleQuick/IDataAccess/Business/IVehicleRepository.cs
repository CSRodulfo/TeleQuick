// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using Business;
using Business.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDataAccess.Repositories
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        Task<IEnumerable<Vehicle>> GetTopActiveVehicles(int count);
        Task<IEnumerable<Vehicle>> GetAllVehiclesData();
    }
}
