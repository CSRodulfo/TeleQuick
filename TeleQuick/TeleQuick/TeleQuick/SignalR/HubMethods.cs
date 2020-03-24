using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeleQuick.Business;

namespace TeleQuick.SignalR
{
    public class HubMethods
    {
        private IHubContext<NotifyHub> _hubContext;
        public HubMethods(IHubContext<NotifyHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public Task WriteMessageAsync(string userId, Message message)
        {
            return _hubContext.Clients.Group(userId).SendAsync("SendMessageUser", message.Concesionary + " - " + message.Description, 10);
        }
    }
}
