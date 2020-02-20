using ScrapySharp.Network;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Core.Autopista.Model;

namespace TeleQuick.Core.IAutopista
{
    public interface IScrapy
    {
        Task<List<HeaderResponse>> Process(WebPage mainPage);
    }
}
