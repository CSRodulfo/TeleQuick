using ScrapySharp.Network;
using System;

namespace TeleQuick.Autopista
{
    public class Connect
    {
        public WebPage webPage;
        protected Connect(string Uri)
        {
            ScrapingBrowser browser = new ScrapingBrowser();

            //set UseDefaultCookiesParser as false if a website returns invalid cookies format
            browser.UseDefaultCookiesParser = false;

            webPage = browser.NavigateToPage(new Uri(Uri));
        }

        private static Connect _instance;

        public static Connect Instance(string Uri)
        {
            // Uses lazy initialization.

            // Note: this is not thread safe.

            if (_instance == null)
            {
                _instance = new Connect(Uri);
            }

            return _instance;
        }
    }
}
