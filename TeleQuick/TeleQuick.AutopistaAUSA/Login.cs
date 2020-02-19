using Business.Models;
using HtmlAgilityPack;
using ScrapySharp.Network;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Core.Autopista.Model;
using TeleQuick.Core.IAutopista;
using TeleQuick.IAutopista;

namespace TeleQuick.AutopistaAUSA
{
    public class Login : ILogin
    {
        AccountSession _accountSession;
        public Login(AccountSession accountSession)
        {
            _accountSession = accountSession;
        }
        public Dictionary<string, string> GetDictionary()
        {
            var dictionary = new Dictionary<string, string>();

            dictionary.Add("_EventName", "EENTER.");
            dictionary.Add("_EventGridId", "");
            dictionary.Add("_EventRowId", "");
            dictionary.Add("_EMPCOD", "6");
            dictionary.Add("_USRCOD", _accountSession.LoginUser);
            dictionary.Add("_USRPSWING", _accountSession.LoginUserPassword);
            dictionary.Add("BTNCONFIRM", "Aceptar");
            dictionary.Add("_MSJDATEMP", "");
            dictionary.Add("_CBIO", "0");
            dictionary.Add("_BAN", "0");
            dictionary.Add("sCallerURL", "");

            return dictionary;
        }

        public string GetMainForm()
        {
            return _accountSession.Concessionary.MainForm;
        }

        public string GetUri()
        {
            return _accountSession.Concessionary.Uri;
        }

        public async Task<bool> LoginValidateAU(IConnectionAU connect)
        {
            bool isValid = false;

            var webPage = await connect.LoginWebPage(this);

            HtmlNode coll = webPage.Html.SelectSingleNode("//*[@id='W0005HEADER_TOP_TABLE']/tbody/tr/td[2]/p/a[3]");

            if (coll != null)
            {
                isValid = true;
            }
            return isValid;
        }
    }
}

