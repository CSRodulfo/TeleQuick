using Business.Models;
using IDataAccess;
using IProvider;
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
        private readonly IProviderService _providerService;

        public AccountSessionService(IUnitOfWork unitOfWork, IProviderService providerService)
        {
            _unitOfWork = unitOfWork;
            _providerService = providerService;
        }

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

                var provider =  _providerService.GetProvider(account.Concessionary);

                //ILogin login = await account.Concessionary.GetLogin();

                //IProviderAU 



                throw new NotImplementedException();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

       

    }
}
