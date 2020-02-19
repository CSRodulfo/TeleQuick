using Business.Models;
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

        public Task<AccountSession> GetById(int id)
        {

            return _appContext.AccountSessions
                                    .Where(x => x.Id == id)
                                    .Include(x => x.Concessionary)
                                    .FirstAsync();

        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
