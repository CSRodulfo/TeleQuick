using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Business.Models;
using TeleQuick.IDataAccess.Repositories;

namespace TeleQuick.IDataAccess.Business
{
    public interface IAccountSessionRepository : IRepository<AccountSession>
    {
        Task<List<AccountSession>> GetAllData();
        Task<List<AccountSession>> GetAllIsValid();
        Task<AccountSession> GetById(int id);
    }
}