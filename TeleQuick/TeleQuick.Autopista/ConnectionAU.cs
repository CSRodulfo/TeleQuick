using HtmlAgilityPack;
using ScrapySharp.Html.Forms;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Core.IAutopista;
using TeleQuick.IAutopista;

namespace TeleQuick.Autopista
{
    public class ConnectionAU : IConnectionAU
    {
        private ScrapingBrowser browser;
        public ConnectionAU()
        {
            browser = new ScrapingBrowser();
            browser.UseDefaultCookiesParser = false;
            browser.AllowAutoRedirect = true;
            browser.AllowMetaRedirect = true;
        }

        public async Task<WebPage> LoginWebPage(ILogin login)
        {
            var webPage = await GetWebPage(login.GetUri());

            PageWebForm form = webPage.FindFormById(login.GetMainForm());

            foreach (var item in login.GetDictionary())
            {
                form[item.Key] = item.Value;
            }
            return form.Submit(new Uri(login.GetUri()));
        }

        public async Task<WebPage> GetWebPage(string Uri)
        {
            return await browser.NavigateToPageAsync(new Uri(Uri));
        }

        public async Task<bool> LoginValidate(ILogin login)
        {
            bool isValid = false;
            var webPage = await this.LoginWebPage(login);

            HtmlNode coll = webPage.Html.SelectSingleNode("//*[@id='W0005HEADER_TOP_TABLE']/tbody/tr/td[2]/p/a[3]");

            if (coll != null)
            {
                isValid = true;
            }
            
            return Convert.ToBoolean(isValid);
            
        }
    }
}
