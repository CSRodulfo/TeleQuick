using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Core.IAutopista;

namespace TeleQuick.IAutopista
{
    public interface IConnectionAU
    {
        //ScrapingBrowser GetBrowser();

        Task<bool> LoginValidate(ILogin login);
        Task<WebPage> LoginWebPage(ILogin login);
        Task<WebPage> GetWebPage(string Uri);
    }
}
