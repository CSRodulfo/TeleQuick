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
            bool finBusqueda = false;
            int ultPos = 0;
            string linea = String.Empty;
            String[] _array = PDFFile.ReadPdfFile(PdffileName).Split('\n');
            if (_array.Length <= 14)
            {
                // return Task;
            }
            linea = _array[14];
            List<String> detalleItem = new List<string>();
            string _strDom = _array[12];
            int posD = _strDom.IndexOf("Dominio:") + 8;
            int posT = _strDom.IndexOf("TAG");
            _strDom = _strDom.Substring(posD, posT - posD).Trim();

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
            List<DetailResponse> list = new List<DetailResponse>();
            foreach (string it in detalleItem)
            {
                DetailResponse id = new DetailResponse();
                int lastSpace = it.LastIndexOf(' ');
                id.Campo4 = it.Substring(lastSpace, it.Length - lastSpace).Trim().Replace(",", ".");
                string[] detArray = it.Substring(0, lastSpace).Trim().Split(' ');
                id.Campo0 = detArray[0];
                id.Campo1 = detArray[1];
                id.Campo2 = detArray[2];
                id.Campo3 = detArray[3];
                id.Campo4 = _strDom;
                for (int i = 4; i < detArray.Length; i++)
                {
                    id.Campo5 += detArray[i] + " ";
                }

                list.Add(id);
            }

            return list;
        }
    }
}
