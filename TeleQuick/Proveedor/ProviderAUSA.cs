using Business.Models;
using IProvider;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Autopista.Login;
using TeleQuick.AutopistaAUSA;
using TeleQuick.Core.Autopista.Model;
using TeleQuick.Core.IAutopista;
using TeleQuick.IAutopista;

namespace Provider
{
    public class ProviderAUSA : IProviderAU
    {
        ILogin _login;
        IScrapy _scrapy;

        public ProviderAUSA(IConnectionAU connection, AccountSession accountSession)
        {
            _login = new LoginAUSA(connection, accountSession);
            _scrapy = new ScrapySixon(connection);
        }

        public async Task<bool> ValidateLogin()
        {
            try
            {
                return await this._login.LoginValidateAU();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<HeaderResponse>> Process()
        {
            WebPage page = await _login.LoginWebPage();

            List <HeaderResponse> list = await _scrapy.Process(page);

            throw new NotImplementedException();
        }
    }
}
