using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeleQuick.Autopista;
using TeleQuick.IAutopista;

namespace TeleQuick.AutopistaAUSOL
{
    public class Login 
    {
        private const string MainForm = "form1";
        private const string Uri = "https://www.ausol.com.ar:91/WebPages/EstadoCuenta/Login.aspx";
        private const string Uri2 = "https://cliente.ausa.com.ar/fael/servlet/";
        private Dictionary<string, string> dictionary;

        IConnection connect;
        WebPage mainPage;

        public Login(IConnection connection)
        {
            dictionary = new Dictionary<string, string>();

            dictionary.Add("__EVENTTARGET", "");
            dictionary.Add("__EVENTARGUMENT", "");
            dictionary.Add("__VIEWSTATE", "/wEPDwUKMTIwNTg3Nzg0NQ9kFgJmD2QWAmYPZBYCAgMPZBYCAgEPZBYCAgUPZBYCAgMPZBYCAgEPZBYCAgcPDxYCHgRUZXh0BR1Vc3VhcmlvIHkvbyBjbGF2ZSBpbmNvcnJlY3RhLmRkZD/rDF03Gf8aAVIFYoP4sR4bJpQ2JxRN5w/dHrZNG7wh");
            dictionary.Add("__EVENTVALIDATION", "/wEdAATyLsBsJ1TieY0y9kTm5btH1VO3WN174VasAB+gV6sG7HmzSSpnW+ut/vc7ck427NZBuK3yZ1uygli5SD0sY0g4QP6jGsduWWUOiH2bmfLVJHDYECUuQ3da125QOOuiwLo=");
            dictionary.Add("ctl00$ctl00$MainContent$ChildContent$txtClienteAusolEmail", "csrodulfo@outlook.com");
            dictionary.Add("ctl00$ctl00$MainContent$ChildContent$txtClienteAusolClave", "Sr4!D!33A3j2NdA");
            dictionary.Add("ctl00$ctl00$MainContent$ChildContent$btnIngresar", "INGRESAR");

            connect = connection;
        }

        public async Task ConnectLogin()
        {
            try
            {
                mainPage = await connect.LoginWebPage(Uri, MainForm, dictionary);
                await Task.FromResult(0);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<List<HeaderResponse>> Process()
        {
            Scrapy scrapy = new Scrapy(mainPage);

            List<HeaderResponse> headers = await scrapy.ScrappHeader();
            foreach (var item in headers)
            {
                await ProcessDetail(item);
            }

            return headers;
        }

        public Task ProcessDetail(HeaderResponse header)
        {
            throw new NotImplementedException();
        }

        public Task ProcessHeader(WebPage mainPage)
        {
            throw new NotImplementedException();
        }
    }
}
