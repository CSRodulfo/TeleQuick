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

namespace Provider
{
    public class ProviderAUSOL : IProviderAU
    {
        IScrapy _scrapy;
        ILogin _login;

        public ProviderAUSOL(IConnectionAU connection, AccountSession accountSession)
        {
            _login = new LoginAUSOL(connection, accountSession);
            _scrapy = new ScrapyB(connection);
        }

        public async Task<bool> ValidateLogin()
        {
            return await this._login.LoginValidateAU();
        }

        public async Task<List<InvoiceHeader>> Process()
        {
            WebPage page = await _login.LoginWebPage();

            List<HeaderResponse> list = await _scrapy.Process(page);

            throw new NotImplementedException();
        }
    }
}
