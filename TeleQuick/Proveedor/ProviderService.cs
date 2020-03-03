using IProvider;
using Provider;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TeleQuick.Business.Models;
using TeleQuick.Core.IAutopista;
using TeleQuick.IService;

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

        public IProviderAU GetProvider(AccountSession accountSession, IEnumerable<Vehicle> vehicles)
        {
            IProviderAU provider = null;

            switch (accountSession.Concessionary.GetAutopista())
            {
                case AutopistasConstants.AUSA:
                    provider = new ProviderAUSA(_connection, accountSession, vehicles, _summary);
                    break;
                case AutopistasConstants.AUSOL:
                    provider = new ProviderAUSOL(_connection, accountSession, vehicles, _summary);
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

        public IProviderAU GetProviderToLogin(AccountSession accountSession)
        {
            return this.GetProvider(accountSession, null);
        }
    }
}
