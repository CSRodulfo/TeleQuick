using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeleQuick.Business;
using TeleQuick.Business.Charts;
using TeleQuick.Business.Models;
using TeleQuick.DataAcces.Repositories;
using TeleQuick.IDataAccess.Business;

namespace TeleQuick.DataAcces.Business
{
    public class InvoiceRepository : Repository<InvoiceHeader>, IInvoiceRepository
    {
        public InvoiceRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<InvoiceHeader>> GetAll(int pageNumber, int pageSize)
        {
            //IQueryable<InvoiceHeader> rolesQuery
            return await appContext.InvoiceHeaders
                .Include(x => x.Concessionary)
                .Include(x => x.InvoiceDetails)
                //.Skip(pageNumber).Take(pageSize)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<ChartConcessionaries>> GetChartDataByConcessionary()
        {
            return await appContext.InvoiceHeaders
               .GroupBy(d => d.Concessionary.Name)
               .Select(
                   g => new ChartConcessionaries
                   {
                       ConcessionaryName = g.Key,
                       Total = g.Sum(s => s.Total)
                   })
               .ToListAsync();
        }

        public async Task<IEnumerable<ChartYear>> GetChartDataByMonth()
        {
            return await appContext.InvoiceHeaders
                .Where(x => x.Date >= System.DateTime.Now.AddMonths(-16))
                .Select(k => new { k.Date.Year, k.Date.Month, k.Total, k.Concessionary.Name })
                .GroupBy(x => new { x.Year, x.Month, x.Name }, (key, group) => new ChartYear
                {
                    Year = key.Year,
                    Month = key.Month,
                    Concessionary = key.Name,
                    Total = group.Sum(k => k.Total )
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ChartVehicle>> GetChartDataByVehicle()
        {
            return await appContext.InvoiceDetails
              .GroupBy(d => d.Vehicle.RegistrationNumber)
              .Select(
                  g => new ChartVehicle
                  {
                      VehicleName = g.Key,
                      Total = g.Sum(s => s.Total)
                  })
              .ToListAsync();
        }
    }
}
