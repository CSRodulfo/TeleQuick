using HtmlAgilityPack;
using ScrapySharp.Html.Forms;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TeleQuick.Autopista;

namespace TeleQuick.AutopistaAUSA
{
    public class Login
    {
        private const string MainForm = "MAINFORM";
        private const string Uri = "https://cliente.ausa.com.ar/fael/servlet/hlogin?6,0";
        private const string Uri2 = "https://cliente.ausa.com.ar/fael/servlet/";

        Dictionary<string, string> dictionary;
        public Login()
        {
            dictionary = new Dictionary<string, string>();

            dictionary.Add("_EventName", "EENTER.");
            dictionary.Add("_EventGridId", "");
            dictionary.Add("_EventRowId", "");
            dictionary.Add("_EMPCOD", "6");
            dictionary.Add("_USRCOD", "363306");
            dictionary.Add("_USRPSWING", "tat406");
            dictionary.Add("BTNCONFIRM", "Aceptar");
            dictionary.Add("_MSJDATEMP", "");
            dictionary.Add("_CBIO", "0");
            dictionary.Add("_BAN", "0");
            dictionary.Add("sCallerURL", "");
        }

        private async Task Connect()
        {
            connect = await Autopista.Connect.Instance(Uri);
        }

        Connect connect;
        public async Task Scrapp()
        {
            await Connect();
            WebPage form = await connect.GetWebPage(MainForm, dictionary);

            Scrapy scrapy = new Scrapy(form);

            scrapy.ScrappHeader();


        }

        public async Task GetDetail(string url)
        {
            WebPage homePage = connect.GetWebPage(Uri2 + url);


            File.WriteAllBytes(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\pepe.pdf", homePage.RawResponse.Body);

            ObtenerDatosDescargados(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\pepe.pdf");


        }

        private void ObtenerDatosDescargados(string PdffileName)
        {
            bool finBusqueda = false;
            int ultPos = 0;
            string linea = String.Empty;
            String[] _array = PDFFile.ReadPdfFile(PdffileName).Split('\n');
            if (_array.Length <= 14)
            {
                return;
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
            //foreach (string it in detalleItem)
            //{
            //    ItemDetalle id = new ItemDetalle();
            //    int lastSpace = it.LastIndexOf(' ');
            //    id.Importe = float.Parse(it.Substring(lastSpace, it.Length - lastSpace).Trim().Replace(",", "."));
            //    string[] detArray = it.Substring(0, lastSpace).Trim().Split(' ');
            //    id.Fecha = detArray[0];
            //    id.Hora = detArray[1];
            //    id.Categoria = int.Parse(detArray[2]);
            //    id.Via = detArray[3];
            //    id.Dominio = _strDom;
            //    for (int i = 4; i < detArray.Length; i++)
            //    {
            //        id.Nombre_Estacion += detArray[i] + " ";
            //    }
            //}
        }
    }
}

