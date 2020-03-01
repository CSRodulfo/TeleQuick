using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Business.Models;
using TeleQuick.DataAcces.Repositories;
using TeleQuick.IDataAccess.Business;

namespace TeleQuick.DataAcces.Business
{
    public class InvoiceRepository : Repository<InvoiceHeader>, IInvoiceRepository
    {
        public InvoiceRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<InvoiceHeader>> GetAll()
        {
            return await appContext.InvoiceHeaders
                .Include(x => x.InvoiceDetails)
                .ToListAsync();
        }
    }
}
