﻿using IProvider;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TeleQuick.Business.Models;
using TeleQuick.IDataAccess.Business;
using TeleQuick.IService;
using ExtensionMethods;

namespace TeleQuick.Service
{
    public class AccountSessionService : IAccountSessionService
    {
        private readonly IAccountSessionRepository _repository;
        private readonly IProviderService _providerService;
        private ObservableCollection<string> _summary;

        public AccountSessionService(IAccountSessionRepository repository, IProviderService providerService,
              ObservableCollection<string> summary)
        {
            _repository = repository;
            _providerService = providerService;
            _summary = summary;
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

        public async Task<List<AccountSession>> Process()
        {
            var account = await _repository.GetAllIsValid();

            await account.ForEachAsync(4, async item =>
             {
                 var provider = await _providerService.GetProvider(item);
                 var list = await provider.Process();
                 item.Concessionary.InvoiceHeaders = list;
                 await _repository.Update(item);
             });

            return  account;
        }
    }
}