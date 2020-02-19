using Business.Models;
using IProvider;
using IService.Business;
using Provider;
using System.Threading.Tasks;
using TeleQuick.IAutopista;

namespace Service.Business
{
    public class ProviderService : IProviderService
    {
        private readonly IConnectionAU _connection;

        public ProviderService(IConnectionAU connection)
        {
            _connection = connection;
        }

        public async Task<IProviderAU> GetProvider(AccountSession accountSession)
        {
            IProviderAU provider = null;

            switch (accountSession.Concessionary.GetAutopista())
            {
                case AutopistasConstants.AUSA:
                    provider = new ProviderAUSA(_connection, accountSession);
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
