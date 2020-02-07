using ScrapySharp.Html.Forms;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using TeleQuick.Autopista;

namespace TeleQuick.AutopistaAUSA
{
    public class AUSALogin
    {
        Dictionary<string, string> dictionary;
        public AUSALogin()
        {
            dictionary = new Dictionary<string, string>();

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

        }

        public WebPage Connect()
        {
            Connect connect = TeleQuick.Autopista.Connect.Instance("https://cliente.ausa.com.ar/fael/servlet/hlogin?6,0");

            PageWebForm form = connect.webPage.FindFormById("MAINFORM");

            foreach (var item in dictionary)
            {
                form[item.Key] = item.Value;
            }

            form.Method = HttpVerb.Post;


            return form.Submit();
        }
    }
}

