using Business.Models;
using Business.Process;
using IProvider;
using IService.Business;
using Provider;
using System.Threading.Tasks;
using TeleQuick.Core.IAutopista;

namespace Service.Business
{
    public class ProviderService : IProviderService
    {
        private IConnectionAU _connection;
        private InvoiceHeaderFactory _invoiceHeader;

        public ProviderService(IConnectionAU connection, InvoiceHeaderFactory invoiceHeader)
        {
            _connection = connection;
            _invoiceHeader = invoiceHeader;
        }

        public async Task<IProviderAU> GetProvider(AccountSession accountSession)
        {
            IProviderAU provider = null;

            switch (accountSession.Concessionary.GetAutopista())
            {
                case AutopistasConstants.AUSA:
                    provider = new ProviderAUSA(_connection, accountSession, _invoiceHeader);
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
