using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        public Task<IEnumerable<InvoiceHeader>> GetChartDataByConcessionary()
        {
            return _invoiceRepository.GetChartDataByConcessionary();
        }
    }
}
