using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Business.Models;
using TeleQuick.IDataAccess.Repositories;

namespace TeleQuick.IDataAccess.Business
{
    public interface IAccountSessionRepository : IRepository<AccountSession>
    {
        Task<IEnumerable<AccountSession>> GetAllData();

        Task<AccountSession> GetById(int id);
    }
}