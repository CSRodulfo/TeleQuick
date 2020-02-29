﻿using TeleQuick.Business.Models;
using IProvider;
using IService.TeleQuick.Business;
using Provider;
using System.Threading.Tasks;
using TeleQuick.Core.Autopista.Model;
using TeleQuick.Core.IAutopista;
using System.Collections.ObjectModel;

namespace Service.TeleQuick.Business
{
    public class ProviderService : IProviderService
    {
        private IConnectionAU _connection;
        private ObservableCollection<string> _summary;

        public ProviderService(IConnectionAU connection, ObservableCollection<string> summary)
        {
            _connection = connection;
            _summary = summary;
        }

        public async Task<IProviderAU> GetProvider(AccountSession accountSession)
        {
            IProviderAU provider = null;

            switch (accountSession.Concessionary.GetAutopista())
            {
                case AutopistasConstants.AUSA:
                    provider = new ProviderAUSA(_connection, accountSession, _summary);
                    break;
                case AutopistasConstants.AUSOL:
                    provider = new ProviderAUSOL(_connection, accountSession);
                    break;
                case AutopistasConstants.AUBASA:
                    break;
                case AutopistasConstants.AUSUR:
                    break;
                case AutopistasConstants.AUOESTE:
                    break;
                case AutopistasConstants.CEAMSE:
                    break;
                default:
                    break;
            }

            return provider;
        }
    }
}
