using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeleQuick.SignalR
{
    public class CallingSideClass
    {
        private readonly IHubContext<NotifyHub, ITypedHubClient> _hubContext;

        public CallingSideClass(IHubContext<NotifyHub, ITypedHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

        public Task BroadcastMessageUser(string userId, Message message)
        {
            return _hubContext.Clients.All.BroadcastMessage(message.Type , "");


        }

        public Task BroadcastMessage(string userId, string message)
        {
            return _hubContext.Clients.All.BroadcastMessage(message, "");

        }
    }
}
