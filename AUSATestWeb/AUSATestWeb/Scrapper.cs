using IronWebScraper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AUSATestWeb
{
    public class Scrapper : WebScraper
    {
        public override void Init()
        {
            License.LicenseKey = "LicenseKey";
            this.LoggingLevel = WebScraper.LogLevel.All;

            this.WorkingDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\Output\";

            this.Request("https://blog.scrapinghub.com", Parse);
        }
        public override void Parse(Response response)
        {
         

            // Loop on all Links
            foreach (var title_link in response.Css(".blog-title h2.site-description"))
            {
                // Read Link Text
                string strTitle = title_link.TextContentClean;
                // Save Result to File
                Scrape(new ScrapedData() { { "Title", strTitle } }, "HelloScraper.Json");
            }
        }
    }
}
