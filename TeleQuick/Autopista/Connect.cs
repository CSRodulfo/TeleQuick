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
        private WebPage webPage;
        public Connect(string Uri)
        {
            browser = new ScrapingBrowser();
            //set UseDefaultCookiesParser as false if a website returns invalid cookies format
            browser.UseDefaultCookiesParser = false;

            webPage = browser.NavigateToPage(new Uri(Uri));
        }

        public async Task<WebPage> LoginWebPage(string MainForm, Dictionary<string, string> dictionary)
        {
            PageWebForm form = webPage.FindFormById(MainForm);

            foreach (var item in dictionary)
            {
                form[item.Key] = item.Value;
            }

            form.Method = HttpVerb.Post;

            return form.Submit();
        }

        public async Task<WebPage> GetWebPage(string Uri)
        {
            return browser.NavigateToPage(new Uri("Uri"));
        }
    }
}
