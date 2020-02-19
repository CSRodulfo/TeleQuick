using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeleQuick.Core.Autopista.Model;

namespace TeleQuick.IAutopista
{
    public interface IScrapy
    {
        Task<List<HeaderResponse>> Process(WebPage mainPage);
    }
}
