using HtmlAgilityPack;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TeleQuick.AutopistaAUSA
{
    public class Scrapy
    {
        WebPage form;
        public Scrapy(WebPage Form )
        {
            form = Form;
        }
        public async Task ScrappHeader()
        {
            HtmlNodeCollection coll = form.Html.SelectNodes("//table[@id='GRID1']/tr");

            foreach (HtmlNode cell in coll)
            {
                var a = cell.ChildNodes.Where(n => n.Name == "td").ToList();

                if (a.Count > 0)
                {
                    var query = a[2].LastChild.Attributes.FirstOrDefault().Value.Substring(18, 26);
                    ScrappDetail(query);
                }

                foreach (HtmlNode cell2 in a)
                {
                    var b = cell2.InnerText.Trim();
                }
            }
        }

        public async Task ScrappDetail(string url)
        {
            //WebPage homePage = connect.GetWebPage(Uri2 + url);


            //File.WriteAllBytes(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\pepe.pdf", homePage.RawResponse.Body);

            //ObtenerDatosDescargados(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\pepe.pdf");


        }
    }
}
