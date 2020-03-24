using IProvider;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TeleQuick.Business.Models;
using TeleQuick.IDataAccess.Business;
using TeleQuick.IService;
using ExtensionMethods;
using System;
using Microsoft.Extensions.Logging;
using TeleQuick.Business;

namespace TeleQuick.Service
{
    public class AccountSessionService : IAccountSessionService
    {
        private readonly IAccountSessionRepository _repository;
        private readonly IVehicleRepository _repositoryVehicle;
        private readonly IProviderService _providerService;
        private ObservableCollection<Message> _summary;
        private readonly ILogger _logger;

        public AccountSessionService(IAccountSessionRepository repository, IProviderService providerService,
              ObservableCollection<Message> summary, ILogger<IAccountSessionService> logger, IVehicleRepository repositoryVehicle)
        {
            _repository = repository;
            _providerService = providerService;
            _summary = summary;
            _repositoryVehicle = repositoryVehicle;
            _logger = logger;
        }

        public async Task<IEnumerable<AccountSession>> Get()
        {
            var allCustomers = _repository.GetAllData();
            return await allCustomers;
        }

        public async Task<AccountSession> GetById(int id)
        {
            return await _repository.GetByIdWithConcesionary(id);
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
            IProviderAU provider = _providerService.GetProviderToLogin(account);

            return await provider.ValidateLogin();
        }

        public async Task<List<AccountSession>> Process()
        {
            var account = await _repository.GetAllIsValid();
            var vehicle = await _repositoryVehicle.GetAll();

            await account.ForEachAsync(4, async item =>
             {
                 try
                 {
                     var provider = _providerService.GetProvider(item, vehicle);
                     var list = await provider.Process();
                     item.Concessionary.InvoiceHeaders = list;
                     await _repository.Update(item);
                 }
                 catch (Exception ex)
                 {
                     _logger.LogError(ex, "Error en procesar");
                     _summary.Add(new Message("ERROR", "Error en procesar" + item.Concessionary.Name));
                 }
             });

            //foreach (var item in account)
            //{
            //    try
            //    {
            //        var provider = await _providerService.GetProvider(item, vehicle);
            //        var list = await provider.Process();
            //        item.Concessionary.InvoiceHeaders = list;
            //        await _repository.Update(item);
            //    }
            //    catch (Exception ex)
            //    {
            //        _logger.LogError(ex, "Error en procesar");
            //        _summary.Add("Error en procesar" + item.Concessionary.Name);
            //    }
            //}

            return account;
        }
    }
}