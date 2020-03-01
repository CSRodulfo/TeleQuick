using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeleQuick.Business.Models;
using TeleQuick.DataAcces.Repositories;
using TeleQuick.IDataAccess.Business;

namespace TeleQuick.DataAcces.Business
{
    public class AccountSessionRepository : Repository<AccountSession>, IAccountSessionRepository
    {
        public AccountSessionRepository(ApplicationDbContext context) :
            base(context)
        { }


        public async Task<IEnumerable<AccountSession>> GetAllData()
        {
            return await appContext.AccountSessions
                                    .Include(x => x.Concessionary)
                                    .ToListAsync();
        }

        public async Task<AccountSession> GetById(int id)
        {
            return appContext.AccountSessions
                                    .Where(x => x.Id == id)
                                    .Include(x => x.Concessionary)
                                    .First();
        }
    }
}
