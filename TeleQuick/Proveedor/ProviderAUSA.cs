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
using TeleQuick.IService;

namespace Provider
{
    public class ProviderAUSA : IProviderAU
    {
        private ILogin _login;
        private IScrapy _scrapy;
        private IInvoiceFactory _invoiceHeader;
        private ICollectionMessage _summary;
        private const string Concessionary = "AUSA";

        public ProviderAUSA(IConnectionAU connection, AccountSession accountSession, IEnumerable<Vehicle> vehicles,
            ICollectionMessage summary)
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

        public async Task<List<InvoiceHeader>> Process(MessageDictionary messages)
        {
            _summary.AddMessage(messages.GetMessage(MyEnum.Logging));

            WebPage page = await _login.LoginWebPage();

            _summary.AddMessage(messages.GetMessage(MyEnum.Logged));

            _summary.AddMessage(messages.GetMessage(MyEnum.Scrapping));

            List<HeaderResponse> list = await _scrapy.Process(page);

            _summary.AddMessage(messages.GetMessage(MyEnum.Scrapped));

            _summary.AddMessage(messages.GetMessage(MyEnum.Procesing));

            List<InvoiceHeader> invoices = await _invoiceHeader.Procees(list);

            _summary.AddMessage(messages.GetMessage(MyEnum.Procesed));

            return invoices;
        }

        public void Validando()
        {

        }
    }
}
