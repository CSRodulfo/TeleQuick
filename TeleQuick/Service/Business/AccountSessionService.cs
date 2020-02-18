using Business.Models;
using IDataAccess;
using IService.Business;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Core.IAutopista;

namespace Service.Business
{
    public class AccountSessionService : IAccountSessionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountSessionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/values
        public async Task<IEnumerable<AccountSession>> Get()
        {
            var allCustomers = _unitOfWork.AccountSessions.GetAllData();
            return await allCustomers;
        }

        public async Task<AccountSession> ValidateConnection(int idAccountSession)
        {
            try
            {
                AccountSession account = await _unitOfWork.AccountSessions.GetById(idAccountSession);

                ILogin login = await account.Concessionary.GetLogin();



                throw new NotImplementedException();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

       

    }
}
