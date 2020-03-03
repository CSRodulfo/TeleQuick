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

namespace Provider
{
    public class ProviderAUSA : IProviderAU
    {
        private ILogin _login;
        private IScrapy _scrapy;
        private InvoiceFactoryAUSA _invoiceHeader;
        private ObservableCollection<string> _summary;

        public ProviderAUSA(IConnectionAU connection, AccountSession accountSession,
            ObservableCollection<string> summary)
        {
            _login = new LoginAUSA(connection, accountSession);
            _scrapy = new ScrapySixon(connection);
            _invoiceHeader = new InvoiceFactoryAUSA();
            _summary = summary;
        }

        public async Task<bool> ValidateLogin()
        {
            return await this._login.LoginValidateAU();
        }

        public async Task<List<InvoiceHeader>> Process()
        {
            //try
            //{
                _summary.Add("Validando login de sesion AUSA");

                WebPage page = await _login.LoginWebPage();

                _summary.Add("Login de sesion AUSA exitoso");

                _summary.Add("Comienzo de Scrapy AUSA");

                List<HeaderResponse> list = await _scrapy.Process(page);

                _summary.Add("Scrapy AUSA exitoso");

                List<InvoiceHeader> invoices = await _invoiceHeader.Procees(list);

                return invoices;

            //}
            //catch (Exception ex)
            //{
            //    _summary.Add("Error en procesar AUSA");
            //    return new List<InvoiceHeader>();
            //}
        }
    }
}
