using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
