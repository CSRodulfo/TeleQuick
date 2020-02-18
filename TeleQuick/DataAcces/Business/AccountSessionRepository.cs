using Business.Models.Business;
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
            return await _appContext.AccountSessions
                                    .Include(x => x.Concessionary)
                                    .FirstAsync(x => x.Id == id);

        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
