using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Core.Autopista.Model;
using TeleQuick.Core.IAutopista;
using TeleQuick.IAutopista;

namespace TeleQuick.AutopistaAUSOL
{
    public class Login : ILogin
    {
        private const string MainForm = "form1";
        private const string Uri = "https://www.ausol.com.ar:91/WebPages/EstadoCuenta/Login.aspx";
        public Login()
        {
        }

        public Dictionary<string, string> GetDictionary()
        {
            var dictionary = new Dictionary<string, string>();

            dictionary.Add("__EVENTTARGET", "");
            dictionary.Add("__EVENTARGUMENT", "");
            dictionary.Add("__VIEWSTATE", "/wEPDwUKMTIwNTg3Nzg0NQ9kFgJmD2QWAmYPZBYCAgMPZBYCAgEPZBYCAgUPZBYCAgMPZBYCAgEPZBYCAgcPDxYCHgRUZXh0BR1Vc3VhcmlvIHkvbyBjbGF2ZSBpbmNvcnJlY3RhLmRkZD/rDF03Gf8aAVIFYoP4sR4bJpQ2JxRN5w/dHrZNG7wh");
            dictionary.Add("__EVENTVALIDATION", "/wEdAATyLsBsJ1TieY0y9kTm5btH1VO3WN174VasAB+gV6sG7HmzSSpnW+ut/vc7ck427NZBuK3yZ1uygli5SD0sY0g4QP6jGsduWWUOiH2bmfLVJHDYECUuQ3da125QOOuiwLo=");
            dictionary.Add("ctl00$ctl00$MainContent$ChildContent$txtClienteAusolEmail", "csrodulfo@outlook.com");
            dictionary.Add("ctl00$ctl00$MainContent$ChildContent$txtClienteAusolClave", "Sr4!D!33A3j2NdA");
            dictionary.Add("ctl00$ctl00$MainContent$ChildContent$btnIngresar", "INGRESAR");

            return dictionary;
        }

        public string GetMainForm()
        {
            return MainForm;
        }

        public string GetUri()
        {
            return Uri;
        }

        public async Task<bool> LoginValidateAU(IConnectionAU connect)
        {
            throw new NotImplementedException();
        }
    }
}
