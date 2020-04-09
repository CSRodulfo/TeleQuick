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
using TeleQuick.IService;

namespace Provider
{
    public class ProviderAUSOL : IProviderAU
    {
        private IScrapy _scrapy;
        private ILogin _login;
        private IInvoiceFactory _invoiceHeader;
        private ICollectionMessage _summary;
        private const string Concessionary = "AUSOL";

        public ProviderAUSOL(IConnectionAU connection, AccountSession accountSession, IEnumerable<Vehicle> vehicles,
            ICollectionMessage summary)
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
    }
}
