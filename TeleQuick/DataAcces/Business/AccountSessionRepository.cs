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


        public async Task<IEnumerable<AccountSession>> GetAllAccountSessionData()
        {
            return await _appContext.AccountSessions
                .ToListAsync();
        }



        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
