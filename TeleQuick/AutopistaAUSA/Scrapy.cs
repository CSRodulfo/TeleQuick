using HtmlAgilityPack;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TeleQuick.Autopista;

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

                HeaderResponse header = new HeaderResponse();
                header.A = a[0].InnerText.Trim();
                header.B = a[1].InnerText.Trim();
                header.C = a[2].InnerText.Trim();
                header.D = a[3].InnerText.Trim();
                header.E = a[4].InnerText.Trim();
                header.F = a[5].InnerText.Trim();
                header.G = a[6].InnerText.Trim();
                header.H = a[7].InnerText.Trim();
                header.I = a[8].InnerText.Trim();
                header.J = a[9].InnerText.Trim();

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
