using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Business.Charts;
using TeleQuick.Business.Models;
using TeleQuick.IDataAccess.Repositories;

namespace TeleQuick.IDataAccess.Business
{
    public interface IInvoiceRepository : IRepository<InvoiceHeader>
    {
        Task<IEnumerable<InvoiceHeader>> GetAll(int pageNumber, int pageSize);
        Task<IEnumerable<ChartConcessionaries>> GetChartDataByConcessionary();
        Task<IEnumerable<ChartVehicle>> GetChartDataByVehicle();
        Task<IEnumerable<ChartData>> GetChartDataByMonth(int month);
        Task<IEnumerable<ChartData>> GetChartDataByTotal(int month);
    }
}
