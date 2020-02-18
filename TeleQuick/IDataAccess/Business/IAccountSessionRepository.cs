using Business.Models.Business;
using IDataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccess.Business
{
    public interface IAccountSessionRepository: IRepository<AccountSession>
    {
        Task<IEnumerable<AccountSession>> GetAllData();

        Task<AccountSession> GetById(int id);
    }
}