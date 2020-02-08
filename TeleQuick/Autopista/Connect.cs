using HtmlAgilityPack;
using ScrapySharp.Html.Forms;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TeleQuick.Autopista
{
    public class Connect
    {
        private ScrapingBrowser browser;
        public Connect()
        {
            browser = new ScrapingBrowser();
            //set UseDefaultCookiesParser as false if a website returns invalid cookies format
            browser.UseDefaultCookiesParser = false;
            browser.AllowAutoRedirect = true;
            browser.AllowMetaRedirect = true;

        }

        public async Task<WebPage> LoginWebPage(string Uri, string MainForm, Dictionary<string, string> dictionary)
        {
            var webPage = await GetWebPage(Uri);




            HtmlNode coll = webPage.Html.SelectSingleNode("//input[@id='__EVENTVALIDATION']");

            var signupFormId = coll.GetAttributeValue("value", "");

            HtmlNode coll2 = webPage.Html.SelectSingleNode("//input[@id='__VIEWSTATE']");

            var signupFormId2 = coll2.GetAttributeValue("value", "");



            PageWebForm form = webPage.FindFormById(MainForm);

            foreach (var item in dictionary)
            {
                form[item.Key] = item.Value;
            }

            form["__VIEWSTATE"] = signupFormId2;
            form["__EVENTVALIDATION"] = signupFormId;

            form.Method = HttpVerb.Post;

            form.SerializeFormFields();

            //webPage. = "https://www.ausol.com.ar:91/WebPages/EstadoCuenta/Login.aspx";

            WebPage results = form.Submit(new Uri( "https://www.ausol.com.ar:91/WebPages/EstadoCuenta/Login.aspx"));
            return form.Submit();
        }

        public async Task<WebPage> GetWebPage(string Uri)
        {
            return browser.NavigateToPage(new Uri(Uri));
        }
    }
}
