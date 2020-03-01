using System;
using System.Collections.Generic;
using System.Text;
using TeleQuick.IDataAccess.Business;

namespace Service
{
    public class InvoiceService
    {

        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }
    }
}
