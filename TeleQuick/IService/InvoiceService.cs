using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeleQuick.Business.Models;

namespace TeleQuick.IService
{
    public interface IInvoiceService
    {
        Task<IEnumerable<InvoiceHeader>> GetAll(int pageNumber, int pageSize);
        Task<InvoiceHeader> GetById(int id);
    }
}
