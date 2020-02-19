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
        private readonly IConnection _connection;

        public ProviderService(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<IProviderAU> GetProvider(Concessionary concessionary)
        {
            IProviderAU provider = null;

            switch (concessionary.GetAutopista())
            {
                case AutopistasConstants.AUSA:
                    provider = new ProviderAUSA(_connection);
                    break;
                case AutopistasConstants.AUSOL:
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
