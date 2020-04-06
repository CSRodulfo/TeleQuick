using TeleQuick.Business.Models;
using IProvider;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Autopista.Login;
using TeleQuick.AutopistaAUSA;
using TeleQuick.Core.Autopista.Model;
using TeleQuick.Core.IAutopista;
using System.Collections.ObjectModel;
using TeleQuick.Business;

namespace Provider
{
    public class ProviderAUSA : IProviderAU
    {
        private ILogin _login;
        private IScrapy _scrapy;
        private IInvoiceFactory _invoiceHeader;
        private ObservableCollection<Message> _summary;
        private const string Concessionary = "AUSA";

        public ProviderAUSA(IConnectionAU connection, AccountSession accountSession, IEnumerable<Vehicle> vehicles,
            ObservableCollection<Message> summary)
        {
            _login = new LoginAUSA(connection, accountSession);
            _scrapy = new ScrapySixon(connection);
            _invoiceHeader = new InvoiceFactoryAUSA(vehicles);
            _summary = summary;
        }

        public ProviderAUSA(IConnectionAU connection, AccountSession accountSession)
        {
            _login = new LoginAUSA(connection, accountSession);
            _scrapy = new ScrapySixon(connection);
        }

        public async Task<bool> ValidateLogin()
        {
            return await this._login.LoginValidateAU();
        }

        public async Task<List<InvoiceHeader>> Process()
        {
            _summary.Add(new Message(Concessionary, "Validando login de sesion"));

            WebPage page = await _login.LoginWebPage();

            _summary.Add(new Message(Concessionary, "Login de sesion exitoso"));

            _summary.Add(new Message(Concessionary, "Comienzo de Scrapy"));

            List<HeaderResponse> list = await _scrapy.Process(page);

            _summary.Add(new Message(Concessionary, "Scrapy exitoso"));

            _summary.Add(new Message(Concessionary, "Comienzo Cabecera y Detalle de exitoso"));

            List<InvoiceHeader> invoices = await _invoiceHeader.Procees(list);

            _summary.Add(new Message(Concessionary, "Cabecera y Detalle de exitoso"));

            return invoices;
        }

        public void Validando()
        {

        }
    }
}
