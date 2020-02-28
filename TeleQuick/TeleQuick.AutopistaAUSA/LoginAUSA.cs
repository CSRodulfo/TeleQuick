﻿using TeleQuick.Business.Models;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Core.IAutopista;

namespace TeleQuick.Autopista.Login
{
    public class LoginAUSA : LoginBase, ILogin
    {
        public LoginAUSA(IConnectionAU connect, AccountSession accountSession):
            base(connect, accountSession)
        {

        }
        public override Dictionary<string, string> GetDictionary()
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

        public override async Task<bool> LoginValidateAU()
        {
            bool isValid = false;

            var webPage = await _connect.LoginWebPage(this);

            HtmlNode coll = webPage.Html.SelectSingleNode("//*[@id='W0005HEADER_TOP_TABLE']/tbody/tr/td[2]/p/a[3]");

            if (coll != null)
            {
                isValid = true;
            }
            return isValid;
        }


    }
}

