using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace AUSATest
{
    public partial class Form1 : Form
    {
        bool _bNavegando = false;
        List<ItemDetalle> lstItems = null;

        public Form1()
        {
            InitializeComponent();
            lstItems = new List<ItemDetalle>();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (wbTest.ReadyState == WebBrowserReadyState.Complete)
            {
                wbTest.Document.GetElementById("_USRCOD").InnerText = "363306";
                wbTest.Document.GetElementById("_USRPSWING").InnerText = "tat406";
                wbTest.Document.GetElementById("BTNCONFIRM").InvokeMember("click");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            wbTest.Navigate(txtUrl.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            HtmlElement tab = wbTest.Document.GetElementById("GRID1");
            HtmlElementCollection rows = tab.GetElementsByTagName("tr");
            int iRow = 1;
            foreach (HtmlElement r in rows)
            {
                try
                {
                    string emp_cod = r.Document.GetElementById("EMPCOD_" + iRow.ToString().PadLeft(4, '0')).GetAttribute("value");
                    string lot_id = r.Document.GetElementById("LOTID_" + iRow.ToString().PadLeft(4, '0')).GetAttribute("value");
                    string lo2rng = r.Document.GetElementById("LO2RNG_" + iRow.ToString().PadLeft(4, '0')).GetAttribute("value");
                    WebClient c = new WebClient();
                    string strFile = "download_" + emp_cod + lot_id + lo2rng + ".pdf";
                    c.DownloadFile(new Uri("https://cliente.ausa.com.ar/fael/servlet/oemidetcweb?" + emp_cod + "," + lot_id + "," + lo2rng + ",PU"), strFile);
                    ObtenerDatosDescargados(strFile);
                }
                catch (Exception ex)
                {

                }
                iRow++;
            }
            Form2 f2 = new Form2();
            f2.grd.DataSource = lstItems;
            f2.ShowDialog();
        }

        public HtmlDocument GetHtmlDocument(string html)
        {
            WebBrowser browser = new WebBrowser();
            browser.ScriptErrorsSuppressed = true;
            browser.DocumentText = html;
            browser.Document.OpenNew(true);
            browser.Document.Write(html);
            browser.Refresh();
            return browser.Document;
        }

        private void wbTest_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            _bNavegando = false;
        }

        public string ReadPdfFile(object Filename)
        {
            PdfReader reader2 = new PdfReader((string)Filename);
            string strText = string.Empty;

            for (int page = 1; page <= reader2.NumberOfPages; page++)
            {
                ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy();
                PdfReader reader = new PdfReader((string)Filename);
                String s = PdfTextExtractor.GetTextFromPage(reader, page, its);

                s = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(s)));
                strText = strText + s;
                reader.Close();
            }
            return strText;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void ObtenerDatosDescargados(string PdffileName)
        {
            bool finBusqueda = false;
            int ultPos = 0;
            string linea = String.Empty;
            String[] _array = ReadPdfFile(PdffileName).Split('\n');
            if (_array.Length <= 14)
            {
                return;
            }
            linea = _array[14];
            List<String> detalleItem = new List<string>();
            string _strDom = _array[12];
            int posD = _strDom.IndexOf("Dominio:")+8;
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
            foreach (string it in detalleItem)
            {                
                ItemDetalle id = new ItemDetalle();
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
                lstItems.Add(id);
            }
        }
    }
}
