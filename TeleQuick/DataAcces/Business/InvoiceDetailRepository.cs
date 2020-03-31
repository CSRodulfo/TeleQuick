using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeleQuick.Business.Models;
using TeleQuick.DataAcces.Repositories;
using TeleQuick.IDataAccess.Business;

namespace TeleQuick.DataAcces.Business
{
    public class InvoiceDetailRepository : Repository<InvoiceDetail>, IInvoiceDetailRepository
    {
        public InvoiceDetailRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<InvoiceDetail>> GetAllDetails(int pageNumber, int pageSize)
        {
            return await appContext.InvoiceDetails
                .Include(x => x.Vehicle)
                .Include(x => x.InvoiceHeader.Concessionary)
                //.Skip(pageNumber).Take(pageSize)
                .OrderBy(x => x.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<InvoiceDetail>> GetByHeaderId(int id)
        {
            return await appContext.InvoiceDetails
              .Where(x => x.InvoiceHeaderId == id)
              .Include(x => x.Vehicle)
              .Include(x => x.InvoiceHeader.Concessionary)
              //.Skip(pageNumber).Take(pageSize)
              .OrderBy(x => x.Date)
              .ToListAsync();
        }
    }
}
