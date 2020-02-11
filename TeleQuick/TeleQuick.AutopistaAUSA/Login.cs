﻿using ScrapySharp.Network;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Core.AutopistaModel;
using TeleQuick.Core.IAutopista;
using TeleQuick.IAutopista;

namespace TeleQuick.AutopistaAUSA
{
    public class Login : ILogin
    {
        private const string MainForm = "MAINFORM";
        private const string Uri = "https://cliente.ausa.com.ar/fael/servlet/hlogin?6,0";

        public Login()
        {

        }
        public Dictionary<string, string> GetDictionary()
        {
            var dictionary = new Dictionary<string, string>();

            dictionary.Add("_EventName", "EENTER.");
            dictionary.Add("_EventGridId", "");
            dictionary.Add("_EventRowId", "");
            dictionary.Add("_EMPCOD", "6");
            dictionary.Add("_USRCOD", "363306");
            dictionary.Add("_USRPSWING", "tat406");
            dictionary.Add("BTNCONFIRM", "Aceptar");
            dictionary.Add("_MSJDATEMP", "");
            dictionary.Add("_CBIO", "0");
            dictionary.Add("_BAN", "0");
            dictionary.Add("sCallerURL", "");

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
    }
}

