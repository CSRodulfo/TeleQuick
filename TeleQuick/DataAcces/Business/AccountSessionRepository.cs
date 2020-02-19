using  Business.Models;
using DataAccess;
using DataAccess.Repositories;
using IDataAccess.Business;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Business
{
    class AccountSessionRepository : Repository<AccountSession>, IAccountSessionRepository
    {
        public AccountSessionRepository(ApplicationDbContext context) : base(context)
        { }


        public async Task<IEnumerable<AccountSession>> GetAllData()
        {
            return await _appContext.AccountSessions
                                    .Include(x => x.Concessionary)
                                    .ToListAsync();
        }

        public async Task<AccountSession> GetById(int id)
        {

            var a = await _appContext.AccountSessions
                                    .Include(x => x.Concessionary)
                                    .FirstOrDefaultAsync(x => x.Id == id);
            return a;

        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
