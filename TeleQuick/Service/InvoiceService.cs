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

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public Task<IEnumerable<InvoiceHeader>> GetAll()
        {
           return _invoiceRepository.GetAll();
        }

        public Task<InvoiceHeader> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
