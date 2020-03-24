using TeleQuick.Business.Models;
using IProvider;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Autopista.Login;
using TeleQuick.AutopistaAUSOL;
using TeleQuick.Core.Autopista.Model;
using TeleQuick.Core.IAutopista;
using System.Collections.ObjectModel;
using TeleQuick.Business;

namespace Provider
{
    public class ProviderAUSOL : IProviderAU
    {
        private IScrapy _scrapy;
        private ILogin _login;
        private IInvoiceFactory _invoiceHeader;
        private ObservableCollection<Message> _summary;

        public ProviderAUSOL(IConnectionAU connection, AccountSession accountSession, IEnumerable<Vehicle> vehicles,
            ObservableCollection<Message> summary)
        {
            _login = new LoginAUSOL(connection, accountSession);
            _scrapy = new ScrapyAUSOL(connection);
            _invoiceHeader = new InvoiceFactoryAUSOL(vehicles);
            _summary = summary;
        }

        public ProviderAUSOL(IConnectionAU connection, AccountSession accountSession)
        {
            _login = new LoginAUSOL(connection, accountSession);
            _scrapy = new ScrapyAUSOL(connection);
        }

        public async Task<bool> ValidateLogin()
        {
            return await this._login.LoginValidateAU();
        }

        public async Task<List<InvoiceHeader>> Process()
        {
            _summary.Add(new Message("AUSOL", "Validando login de sesion"));

            WebPage page = await _login.LoginWebPage();

            _summary.Add(new Message("AUSOL", "Login de sesion exitoso"));

            _summary.Add(new Message("AUSOL", "Comienzo de Scrapy"));

            List<HeaderResponse> list = await _scrapy.Process(page);

            _summary.Add(new Message("AUSOL", "Scrapy exitoso"));

            _summary.Add(new Message("AUSOL", "Comienzo Cabecera y Detalle de exitoso"));

            List<InvoiceHeader> invoices = await _invoiceHeader.Procees(list);

            _summary.Add(new Message("AUSOL", "Cabecera y Detalle de exitoso"));

            return invoices;
        }
    }
}
