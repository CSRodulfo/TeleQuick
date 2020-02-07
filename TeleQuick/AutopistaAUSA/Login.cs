using HtmlAgilityPack;
using ScrapySharp.Html.Forms;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TeleQuick.Autopista;
using TeleQuick.IAutopista;

namespace TeleQuick.AutopistaAUSA
{
    public class Login : IConnection
    {
        private const string MainForm = "MAINFORM";
        private const string Uri = "https://cliente.ausa.com.ar/fael/servlet/hlogin?6,0";
        private const string Uri2 = "https://cliente.ausa.com.ar/fael/servlet/";
        private Dictionary<string, string> dictionary;

        Connect connect;

        public Login()
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

            connect = new Connect();
        }
        public async Task ConnectLogin()
        {
            WebPage mainPage = await connect.LoginWebPage(Uri, MainForm, dictionary);
            await this.ProcessHeader(mainPage);
        }
        public async Task ProcessHeader(WebPage mainPage)
        {
            Scrapy scrapy = new Scrapy(mainPage);

            List<HeaderResponse> headers = await  scrapy.ScrappHeader();
            foreach (var item in headers)
            {
                await ProcessDetail(item);
            }
        }
        public async Task ProcessDetail(HeaderResponse header)
        {

            WebPage homePage = await connect.GetWebPage(Uri2 + header.Campo2);

            ScrapyDetail scrapy = new ScrapyDetail(homePage);

            header.Details.AddRange(await scrapy.ScrappDetail());

        }
    }
}

