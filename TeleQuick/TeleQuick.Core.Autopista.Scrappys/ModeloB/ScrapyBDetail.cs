using HtmlAgilityPack;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TeleQuick.Core.Autopista.Model;

namespace TeleQuick.Core.Autopista.Scrappys.ModeloB
{
    public class ScrapyBDetail
    {
        HtmlNodeCollection _nodes;
        public ScrapyBDetail(HtmlNodeCollection nodes)
        {
            _nodes = nodes;
        }

        public async Task<List<DetailResponse>> ScrappDetail()
        {

            _nodes.RemoveAt(0);

            List<DetailResponse> list = new List<DetailResponse>();

            string cabecera = string.Empty;

            foreach (var item in _nodes)
            {
                DetailResponse detail = new DetailResponse();

                HtmlNode[] nodeArray = item.ChildNodes.Where(n => n.Name == "td").ToArray();

                if (!string.IsNullOrEmpty(HttpUtility.HtmlDecode(nodeArray[0].InnerText).Trim()))
                {

                    cabecera = nodeArray[0].InnerText.Trim();
                    continue;
                }

                detail.Campo0 = cabecera;
                detail.Campo1 = nodeArray[0].InnerText.Trim();
                detail.Campo2 = nodeArray[1].InnerText.Trim();
                detail.Campo3 = nodeArray[2].InnerText.Trim();
                detail.Campo4 = nodeArray[3].InnerText.Trim();

                list.Add(detail);

            }

            return list; //await Task.Run(() => );
        }
    }
}
