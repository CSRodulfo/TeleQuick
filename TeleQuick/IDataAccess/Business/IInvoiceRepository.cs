using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeleQuick.Business.Models;
using TeleQuick.IDataAccess.Repositories;

namespace TeleQuick.IDataAccess.Business
{
    public interface IInvoiceRepository : IRepository<InvoiceHeader>
    {
        Task<IEnumerable<InvoiceHeader>> GetAll(int pageNumber, int pageSize);
    }
}
