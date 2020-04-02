using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Business.Charts;
using TeleQuick.Business.Models;

namespace TeleQuick.IService
{
    public interface IInvoiceService
    {
        Task<IEnumerable<InvoiceDetail>> GetAllDetails(int pageNumber, int pageSize);
        Task<IEnumerable<InvoiceHeader>> GetAll(int pageNumber, int pageSize);
        Task<IEnumerable<InvoiceDetail>> GetByHeaderId(int id);
        Task<IEnumerable<ChartConcessionaries>> GetChartDataByConcessionary();
        Task<IEnumerable<ChartVehicle>> GetChartDataByVehicle();
        IEnumerable<ChartData> GetChartDataByMonth();
    }
}
