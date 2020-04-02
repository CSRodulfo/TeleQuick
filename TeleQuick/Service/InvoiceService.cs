using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeleQuick.Business.Charts;
using TeleQuick.Business.Models;
using TeleQuick.IDataAccess.Business;
using TeleQuick.IService;

namespace TeleQuick.Service
{
    public class InvoiceService : IInvoiceService
    {

        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IInvoiceDetailRepository _invoiceDetailRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository, IInvoiceDetailRepository invoiceDetailRepository)
        {
            _invoiceRepository = invoiceRepository;
            _invoiceDetailRepository = invoiceDetailRepository;
        }

        public Task<IEnumerable<InvoiceHeader>> GetAll(int pageNumber, int pageSize)
        {
            return _invoiceRepository.GetAll(pageNumber, pageSize);
        }

        public Task<IEnumerable<InvoiceDetail>> GetAllDetails(int pageNumber, int pageSize)
        {
            return _invoiceDetailRepository.GetAllDetails(pageNumber, pageSize);
          
        }

        public Task<IEnumerable<InvoiceDetail>> GetByHeaderId(int id)
        {
            return _invoiceDetailRepository.GetByHeaderId(id);
        }

        public Task<IEnumerable<ChartConcessionaries>> GetChartDataByConcessionary()
        {
            return _invoiceRepository.GetChartDataByConcessionary();
        }

        public IEnumerable<ChartData> GetChartDataByMonth()
        {

            return  _invoiceRepository.GetChartDataByMonth().Result
            .GroupBy(x => x.Concessionary).Select(x => new ChartData { label = x.Key, data = x });

        }

        public Task<IEnumerable<ChartVehicle>> GetChartDataByVehicle()
        {
            return _invoiceRepository.GetChartDataByVehicle();
        }
    }
}
