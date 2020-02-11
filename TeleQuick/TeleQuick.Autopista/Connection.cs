using HtmlAgilityPack;
using ScrapySharp.Html.Forms;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.IAutopista;

namespace TeleQuick.Autopista
{
    public class Connection : IConnection
    {
        private ScrapingBrowser browser;
        public Connection()
        {
            browser = new ScrapingBrowser();
            browser.UseDefaultCookiesParser = false;
            browser.AllowAutoRedirect = true;
            browser.AllowMetaRedirect = true;
        }

        public async Task<WebPage> LoginWebPage(string Uri, string MainForm, Dictionary<string, string> dictionary)
        {
            var webPage = await GetWebPage(Uri);

            PageWebForm form = webPage.FindFormById(MainForm);

            foreach (var item in dictionary)
            {
                form[item.Key] = item.Value;
            }
            return form.Submit(new Uri(Uri));
        }

        public async Task<WebPage> GetWebPage(string Uri)
        {
            return await browser.NavigateToPageAsync(new Uri(Uri));
        }

        public ScrapingBrowser GetBrowser()
        {
            return browser;
        }
    }
}
