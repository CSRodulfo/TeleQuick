using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Autopista;

namespace TeleQuick.IAutopista
{
    public interface IHighwayProcessable
    {
        Task ConnectLogin();
        Task<List<HeaderResponse>> Process();
    }
}
