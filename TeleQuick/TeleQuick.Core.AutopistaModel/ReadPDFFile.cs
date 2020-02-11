using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System;
using System.IO;
using System.Text;

namespace TeleQuick.Core.Autopista.Model
{
    public static class PDFFile
    {
        public static string ReadPdfFile(byte[] bytes)
        {
            PdfReader reader = new PdfReader( new MemoryStream(bytes));
            PdfDocument document = new PdfDocument(reader);
            string strText = string.Empty;

            for (int page = 1; page <= document.GetNumberOfPages(); page++)
            {
                ITextExtractionStrategy its = new SimpleTextExtractionStrategy();
                String s = PdfTextExtractor.GetTextFromPage(document.GetPage(page), its);

                s = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(s)));
                strText = strText + s;
            }
            return strText;
        }
    }
}
