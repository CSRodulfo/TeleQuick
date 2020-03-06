using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeleQuick.Business.Models;
using TeleQuick.IDataAccess.Repositories;

namespace TeleQuick.IDataAccess.Business
{
    public interface IInvoiceDetailRepository : IRepository<InvoiceDetail>
    {
        Task<IEnumerable<InvoiceDetail>> GetAllDetails(int pageNumber, int pageSize);
        Task<IEnumerable<InvoiceDetail>> GetByHeaderId(int id);
    }
}
