﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<InvoiceHeader>> GetAll(int pageNumber, int pageSize)
        {
            //IQueryable<InvoiceHeader> rolesQuery
            return await appContext.InvoiceHeaders
                .Include(x => x.Concessionary)
                .Include(x => x.InvoiceDetails)
                //.Skip(pageNumber).Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<InvoiceDetail>> GetAllDetails(int pageNumber, int pageSize)
        {
            //IQueryable<InvoiceHeader> rolesQuery
            return await appContext.InvoiceDetails
                .Include(x => x.Vehicle)
                //.Skip(pageNumber).Take(pageSize)
                .ToListAsync();
        }
    }
}
