using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Core.Autopista.Model;

namespace TeleQuick.AutopistaAUSA
{
    public class ScrapyDetail
    {

        WebPage form;
        public ScrapyDetail(WebPage Form)
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
                id.Importe = float.Parse(it.Substring(lastSpace, it.Length - lastSpace).Trim().Replace(",", "."));
                string[] detArray = it.Substring(0, lastSpace).Trim().Split(' ');
                id.Fecha = detArray[0];
                id.Hora = detArray[1];
                id.Categoria = int.Parse(detArray[2]);
                id.Via = detArray[3];
                id.Dominio = _strDom;
                for (int i = 4; i < detArray.Length; i++)
                {
                    id.Nombre_Estacion += detArray[i] + " ";
                }

                list.Add(id);
            }

            return  list;
        }
    }
}
