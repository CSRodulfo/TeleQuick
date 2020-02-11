using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TeleQuick.IAutopista
{
    public interface IConnection
    {
        ScrapingBrowser GetBrowser();
        Task<WebPage> LoginWebPage(string Uri, string MainForm, Dictionary<string, string> dictionary);
        Task<WebPage> GetWebPage(string Uri);
    }
}
