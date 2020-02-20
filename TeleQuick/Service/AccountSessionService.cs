using Business.Models;
using IDataAccess;
using IProvider;
using IService.Business;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<bool> ValidateConnection(int idAccountSession)
        {

            AccountSession account = await _unitOfWork.AccountSessions.GetById(idAccountSession);

            IProviderAU provider = await _providerService.GetProvider(account);

            return await provider.ValidateLogin();
        }
    }
}
