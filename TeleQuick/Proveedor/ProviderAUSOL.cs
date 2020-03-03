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

namespace Provider
{
    public class ProviderAUSOL : IProviderAU
    {
        private IScrapy _scrapy;
        private ILogin _login;
        private IInvoiceFactory _invoiceHeader;
        private ObservableCollection<string> _summary;

        public ProviderAUSOL(IConnectionAU connection, AccountSession accountSession, IEnumerable<Vehicle> vehicles,
            ObservableCollection<string> summary)
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
            //try
            //{
            _summary.Add("Validando login de sesion AUSOL");

            WebPage page = await _login.LoginWebPage();

            _summary.Add("Login de sesion AUSOL exitoso");

            _summary.Add("Comienzo de Scrapy AUSOL");

            List<HeaderResponse> list = await _scrapy.Process(page);

            _summary.Add("Scrapy AUSOL exitoso");

            List<InvoiceHeader> invoices = await _invoiceHeader.Procees(list);

            return invoices;

            //}
            //catch (Exception)
            //{
            //    _summary.Add("Error en procesar AUSOL");
            //    return new List<InvoiceHeader>();
            //}
        }
    }
}
