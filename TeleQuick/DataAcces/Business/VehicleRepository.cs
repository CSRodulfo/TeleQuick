// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using DataAccess.Repositories;
using IDataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeleQuick.Business.Models;
using TeleQuick.DataAcces;

namespace DataAcces.TeleQuick.Business
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(ApplicationDbContext context) : base(context)
        { }

        public async Task<IEnumerable<Vehicle>> GetAll()
        {
            return await _appContext.Vehicles
                .Include(x => x.TagRfids)
                .OrderBy(c => c.Year)
                .ToListAsync();
        }

        public async Task<Vehicle> GetByIdAll(int id)
        {
            return await _appContext.Vehicles
                .Where(x => x.Id == id)
                .Include(x => x.TagRfids)
                .OrderBy(c => c.Year)
                .FirstAsync();
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)Context;
    }
}
