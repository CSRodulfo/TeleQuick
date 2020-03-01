﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeleQuick.Business.Models;
using TeleQuick.DataAcces.Repositories;
using TeleQuick.IDataAccess.Business;

namespace TeleQuick.DataAcces.Business
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Vehicle>> GetAll()
        {
            return await appContext.Vehicles
                .Include(x => x.TagRfids)
                .OrderBy(c => c.Year)
                .ToListAsync();
        }

        public async Task<Vehicle> GetByIdAll(int id)
        {
            return await appContext.Vehicles
                .Where(x => x.Id == id)
                .Include(x => x.TagRfids)
                .OrderBy(c => c.Year)
                .FirstAsync();
        }
    }
}
