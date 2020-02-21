using Business.Models;
using IDataAccess;
using IDataAccess.Business;
using IDataAccess.Repositories;
using IProvider;
using IService.Business;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Business
{
    public class AccountSessionService : IAccountSessionService
    {
        private readonly IAccountSessionRepository _repository;
        private readonly IProviderService _providerService;

        public AccountSessionService(IAccountSessionRepository repository, IProviderService providerService)
        {
            _repository = repository;
            _providerService = providerService;
        }

        public async Task<IEnumerable<AccountSession>> Get()
        {
            var allCustomers = _repository.GetAllData();
            return await allCustomers;
        }

        public async Task<AccountSession> GetById(int id)
        {
            return await _repository.GetById(id);
        }
        public async Task<int> Create(AccountSession account)
        {
            return await _repository.Add(account);
        }

        public async Task<int> Update(AccountSession account)
        {
            return await _repository.Update(account);
        }

        public async Task<bool> ValidateConnection(AccountSession account)
        {
            IProviderAU provider = await _providerService.GetProvider(account);

            return await provider.ValidateLogin();
        }

        public async Task<List<InvoiceHeader>> Process(AccountSession account)
        {
            IProviderAU provider = await _providerService.GetProvider(account);

            return await provider.Process();
        }
    }
}
