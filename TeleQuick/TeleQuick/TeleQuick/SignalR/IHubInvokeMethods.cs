using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeleQuick.SignalR
{
    public interface IHubInvokeMethods
    {
        Task SendMessageUser(string userId, Message message);
    }
}
