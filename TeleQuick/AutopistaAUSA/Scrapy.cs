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
        public Scrapy(WebPage Form)
        {
            form = Form;
        }
        public async Task<List<HeaderResponse>> ScrappHeader()
        {
            List<HeaderResponse> list = new List<HeaderResponse>();
            HtmlNodeCollection coll = form.Html.SelectNodes("//table[@id='GRID1']/tr");
            coll.RemoveAt(0);

            foreach (HtmlNode cell in coll)
            {
                var a = cell.ChildNodes.Where(n => n.Name == "td").ToList();

                HeaderResponse header = new HeaderResponse();
 
                header.Campo0 = a[0].InnerText.Trim();
                header.Campo1 = a[1].InnerText.Trim();
                header.Campo2 = a[2].LastChild.Attributes.FirstOrDefault().Value.Substring(18, 26);
                header.Campo3 = a[3].InnerText.Trim();
                header.Campo4 = a[4].InnerText.Trim();
                header.Campo5 = a[5].InnerText.Trim();
                header.Campo6 = a[6].InnerText.Trim();
                header.Campo7 = a[7].InnerText.Trim();
                header.Campo8 = a[8].InnerText.Trim();
                header.Campo9 = a[9].InnerText.Trim();
                header.Campo10 = a[10].InnerText.Trim();
                header.Campo11 = a[11].InnerText.Trim();
                header.Campo12 = a[12].InnerText.Trim();
                header.Campo13 = a[13].InnerText.Trim();
                header.Campo14 = a[14].InnerText.Trim();
                header.Campo15 = a[15].InnerText.Trim();
                header.Campo16 = a[16].InnerText.Trim();
                header.Campo17 = a[17].InnerText.Trim();
                header.Campo18 = a[18].InnerText.Trim();
                header.Campo19 = a[19].InnerText.Trim();
                header.Campo20 = a[20].InnerText.Trim();
                header.Campo21 = a[21].InnerText.Trim();
                header.Campo22 = a[22].InnerText.Trim();
                header.Campo23 = a[23].InnerText.Trim();
                header.Campo24 = a[24].InnerText.Trim();
                header.Campo25 = a[25].InnerText.Trim();
                header.Campo26 = a[26].InnerText.Trim();
                header.Campo27 = a[27].InnerText.Trim();
                header.Campo28 = a[28].InnerText.Trim();
                header.Campo29 = a[29].InnerText.Trim();
                header.Campo30 = a[30].InnerText.Trim();
                header.Campo31 = a[31].InnerText.Trim();
                header.Campo32 = a[32].InnerText.Trim();
                header.Campo33 = a[33].InnerText.Trim();
                header.Campo34 = a[34].InnerText.Trim();
                header.Campo35 = a[35].InnerText.Trim();

                list.Add(header);
            }
            return list;
        }
    }
}
