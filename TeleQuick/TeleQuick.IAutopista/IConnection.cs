using ScrapySharp.Network;
using System;
using System.Threading.Tasks;
using TeleQuick.Autopista;

namespace TeleQuick.IAutopista
{
    public interface IConnection
    {
        Task ConnectLogin();
        Task ProcessHeader(WebPage mainPage);

        Task ProcessDetail(HeaderResponse header);
    }
}
