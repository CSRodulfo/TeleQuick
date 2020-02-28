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

namespace Provider
{
    public class ProviderAUSA : IProviderAU
    {
        ILogin _login;
        IScrapy _scrapy;
        InvoiceFactoryAUSA _invoiceHeader;

        public ProviderAUSA(IConnectionAU connection, AccountSession accountSession)
        {
            _login = new LoginAUSA(connection, accountSession);
            _scrapy = new ScrapySixon(connection);
            _invoiceHeader = new InvoiceFactoryAUSA();
        }

        public async Task<bool> ValidateLogin()
        {
            return await this._login.LoginValidateAU();
        }

        public async Task<List<InvoiceHeader>> Process()
        {
            WebPage page = await _login.LoginWebPage();

            List<HeaderResponse> list = await _scrapy.Process(page);

            List<InvoiceHeader> invoices = await _invoiceHeader.Procees(list);

            return invoices;
        }
    }
}
