// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using Business.Models;
using DataAccess;
using DataAccess.Repositories;
using IDataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcces.Business
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(ApplicationDbContext context) : base(context)
        { }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesData()
        {
            return await _appContext.Vehicles
                .Include(x => x.TAGs)
                .OrderBy(c => c.Year)
                .ToListAsync();
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
