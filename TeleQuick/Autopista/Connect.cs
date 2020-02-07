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
        }

        public async Task<WebPage> LoginWebPage(string Uri, string MainForm, Dictionary<string, string> dictionary)
        {
            var webPage = await GetWebPage(Uri);

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
            return await browser.NavigateToPageAsync(new Uri(Uri));
        }
    }
}
