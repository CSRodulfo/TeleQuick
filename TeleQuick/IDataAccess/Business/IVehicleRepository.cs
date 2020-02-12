// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using Business;
using Business.Business;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IDataAccess.Repositories
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        IEnumerable<Vehicle> GetTopActiveVehicles(int count);
        IEnumerable<Vehicle> GetAllVehiclesData();
    }
}
