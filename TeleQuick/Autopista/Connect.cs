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
        protected Connect(string Uri)
        {
            browser = new ScrapingBrowser();
            //set UseDefaultCookiesParser as false if a website returns invalid cookies format
            browser.UseDefaultCookiesParser = false;

            webPage = browser.NavigateToPage(new Uri(Uri));
        }

        private static Connect _instance;

        public static async Task<Connect> Instance(string Uri)
        {
            // Uses lazy initialization.

            // Note: this is not thread safe.

            if (_instance == null)
            {
                _instance = new Connect(Uri);
            }

            return _instance;
        }

        public async Task<WebPage> GetWebPage(string MainForm, Dictionary<string, string> dictionary)
        {
            PageWebForm form = _instance.webPage.FindFormById(MainForm);

            foreach (var item in dictionary)
            {
                form[item.Key] = item.Value;
            }

            form.Method = HttpVerb.Post;

            return form.Submit();
        }

        public WebPage GetWebPage(string Uri)
        {
            return browser.NavigateToPage(new Uri("Uri"));
        }
    }
}
