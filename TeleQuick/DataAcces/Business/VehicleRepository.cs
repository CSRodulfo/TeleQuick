// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Business;
using IDataAccess.Repositories;
using Business.Business;
using DataAccess.Repositories;
using DataAccess;

namespace DataAcces.Business
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(ApplicationDbContext context) : base(context)
        { }


        public IEnumerable<Vehicle> GetTopActiveVehicles(int count)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Vehicle> GetAllVehiclesData()
        {
            return _appContext.Vehicles
                .OrderBy(c => c.Year)
                .ToList();
        }



        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
