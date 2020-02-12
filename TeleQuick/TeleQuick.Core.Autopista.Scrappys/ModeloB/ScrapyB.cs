using HtmlAgilityPack;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeleQuick.Core.Autopista.Model;
using TeleQuick.IAutopista;

namespace TeleQuick.AutopistaAUSOL
{
    public class ScrapyB : IScrapy
    {
        IConnection _connection;
        WebPage _mainWebPage;
        private const string Uri2 = "https://www.ausol.com.ar:91/WebPages/EstadoCuenta/";

        public ScrapyB(IConnection connection, WebPage mainWebPage)
        {
            _connection = connection;
            _mainWebPage = mainWebPage;
        }

        public async Task<List<HeaderResponse>> Process()
        {
            return await this.ScrappHeader(_mainWebPage);
        }

        private async Task<List<HeaderResponse>> ScrappHeader(WebPage mainPage)
        {
            return await this.ProcessHeader();
        }

        public async Task<List<HeaderResponse>> ProcessHeader()
        {
            List<HeaderResponse> list = new List<HeaderResponse>();
            HtmlNodeCollection coll = await Task.Run(() => _mainWebPage.Html.SelectNodes("//*[@id='MainContent_ChildContent_gdvCuentas_hlnkDescripcion_0']"));

            foreach (HtmlNode cell in coll)
            {
                list.Add(await ProcessHeader(cell));
            }

            return list;
        }

        private async Task<HeaderResponse> ProcessHeader(HtmlNode node)
        {
            var b = node.Attributes["href"].Value;

            var nodeArray = node.ChildNodes.Where(n => n.Name == "td").ToArray();

            string uri = String.Concat(Uri2, b);

            WebPage homePage = await _connection.GetWebPage(uri);

            HtmlNode coll =   homePage.Html.SelectSingleNode("//*[@id='MainContent_ChildContent_hlnkFacturas']");

            var c = coll.Attributes["href"].Value;

            string uri2 = String.Concat(Uri2, c);

            WebPage homePage2 = await _connection.GetWebPage(uri2);

            HtmlNodeCollection coll3 = homePage2.Html.SelectNodes("//table[@id='MainContent_ChildContent_dgrvFacturas']/tr");

            //var d = coll3.Attributes["href"].Value;

            HeaderResponse header = await Task.Run(() => GenerateHeader(nodeArray));

            await Task.Run(() => ProcessDetail(header));

            return header;
        }

        public Task ProcessDetail(HeaderResponse header)
        {
            throw new NotImplementedException();
        }

        private HeaderResponse GenerateHeader(HtmlNode[] a)
        {
            HeaderResponse header = new HeaderResponse();

            header.Campo0 = a[0].InnerText.Trim();
            header.Campo1 = a[1].InnerText.Trim();
            header.Campo2 = a[2].InnerText.Trim();
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

            return header;
        }

    }
}
