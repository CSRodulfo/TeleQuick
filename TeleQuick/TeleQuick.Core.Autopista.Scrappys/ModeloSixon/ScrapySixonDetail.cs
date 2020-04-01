using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Core.Autopista.Model;

namespace TeleQuick.AutopistaAUSA
{
    public class ScrapySixonDetail
    {
        WebPage form;
        public ScrapySixonDetail(WebPage Form)
        {
            form = Form;
        }

        public async Task<List<DetailResponse>> ScrappDetail()
        {
            return await Task.Run(() => ObtenerDatosDescargados(form.RawResponse.Body));
        }

        private async Task<List<DetailResponse>> ObtenerDatosDescargados(byte[] PdffileName)
        {
            String[] _array = PDFFile.ReadPdfFile(PdffileName).Split('\n');
            List<DetailResponse> list = new List<DetailResponse>();

            for (int i = 14; i < _array.Length; i += 3)
            {
                List<String> detalleItem = new List<string>();
                bool finBusqueda = false;
                int ultPos = 0;
                string linea = String.Empty;
                linea = _array[i];

                string _item = _array[i - 2];
                int posD = _item.IndexOf("Dominio:") + 8;
                int posT = _item.IndexOf("TAG");
                var _strDom = _item.Substring(posD, posT - posD).Trim();
                var _strTag = _item.Substring(_item.Length - 12, 12).Trim();

                while (!finBusqueda)
                {
                    int pos = linea.IndexOf(',', ultPos);
                    if (pos > 0)
                    {
                        detalleItem.Add(linea.Substring(ultPos, (pos + 3 - ultPos)));
                        ultPos = pos + 3;
                    }
                    if (pos == -1 || ultPos >= linea.Length || linea.IndexOf("*") < 5)
                    {
                        finBusqueda = true;
                    }
                }

                foreach (string it in detalleItem)
                {
                    DetailResponse id = new DetailResponse();
                    int lastSpace = it.LastIndexOf(' ');
                    id.Campo6 = it.Substring(lastSpace, it.Length - lastSpace).Trim().Replace(",", ".");
                    string[] detArray = it.Substring(0, lastSpace).Trim().Split(' ');
                    id.Campo0 = detArray[0];
                    id.Campo1 = detArray[1];
                    id.Campo2 = detArray[2];
                    id.Campo3 = detArray[3];
                    id.Campo4 = _strDom;
                    id.Campo7 = _strTag;
                    for (int l = 4; l < detArray.Length; l++)
                    {
                        id.Campo5 += detArray[l] + " ";
                    }

                    list.Add(id);
                }
            }
            return list;
        }
    }
}
