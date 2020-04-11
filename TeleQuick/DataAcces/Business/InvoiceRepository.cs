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
                       Labels = g.Key,
                       Data = g.Sum(s => s.Total)
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
                      Labels = g.Key,
                      Data = g.Sum(s => s.Total)
                  })
              .ToListAsync();
        }

        public async Task<IEnumerable<ChartData>> GetChartData(int month)
        {
            var baseData = GetChartDataBase(month);

            var a = this.ChartDataGroup(ChartDataByMonth(baseData));
            var b = this.ChartDataGroup(ChartDataByTotal(baseData));

            return b.Union(a).AsEnumerable();
        }

        private IList<ChartYear> ChartDataByMonth(IQueryable<InvoiceHeader> data)
        {
            return data
                .Select(k => new { k.Date.Year, k.Date.Month, k.Total, k.Concessionary.Name })
                .GroupBy(x => new { x.Year, x.Month, x.Name }, (key, group) => new ChartYear
                {
                    IdYearMonth = string.Concat(key.Year, key.Month), // Equivale a Select(m => m.ToString("yyyyM")
                    Month = key.Month,
                    Description = key.Name,
                    Total = group.Sum(k => k.Total)
                })
                .ToList();
        }

        public IList<ChartYear> ChartDataByTotal(IQueryable<InvoiceHeader> data)
        {
            return data
                .Select(k => new { k.Date.Year, k.Date.Month, k.Total })
                .GroupBy(x => new { x.Year, x.Month }, (key, group) => new ChartYear
                {
                    IdYearMonth = string.Concat(key.Year, key.Month),
                    Month = key.Month,
                    Description = "Total",
                    Total = group.Sum(k => k.Total)
                })
                .ToList();
        }

        private IQueryable<InvoiceHeader> GetChartDataBase(int month)
        {
            return appContext.InvoiceHeaders
                .Where(x => x.Date >= System.DateTime.Now.AddMonths(month))
                .AsQueryable();
        }

        public IEnumerable<ChartData> ChartDataGroup(IList<ChartYear> groupList)
        {
            return groupList
                .GroupBy(x => x.Description)
                .Select(x => new ChartData { label = x.Key, data = x.OrderBy(m => m.IdYearMonth).ToList() })
                .ToList();
        }
    }
}
