using Business.Models;
using Business.Process;
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
        InvoiceHeaderFactory _invoiceHeader;

        public ProviderAUSA(IConnectionAU connection, AccountSession accountSession, InvoiceHeaderFactory invoiceHeader)
        {
            _login = new LoginAUSA(connection, accountSession);
            _scrapy = new ScrapySixon(connection);
            _invoiceHeader = invoiceHeader;
        }

        public async Task<bool> ValidateLogin()
        {
            return await this._login.LoginValidateAU();
        }

        public async Task<List<InvoiceHeader>> Process()
        {
            WebPage page = await _login.LoginWebPage();

            List<HeaderResponse> list = await _scrapy.Process(page);

            foreach (var item in list)
            {
                var a = _invoiceHeader.Create(item);
            }

            throw new NotImplementedException();
        }
    }
}
