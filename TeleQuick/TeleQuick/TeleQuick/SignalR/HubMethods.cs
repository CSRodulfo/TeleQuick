using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeleQuick.Business;
using TeleQuick.Controllers;
using TeleQuick.Helpers;

namespace TeleQuick.SignalR
{
    public class HubMethods
    {
        private IHubContext<NotifyHub> _hubContext;
        private readonly ILogger _logger;
        public HubMethods(IHubContext<NotifyHub> hubContext, ILogger<NotifyHub> logger)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        public Task WriteMessageAsync(string userId, Message message)
        {
            if (message != null)
            {
                _logger.LogInformation(LoggingEvents.HUB, message.Concesionary + " - " + message.Description);
                return _hubContext.Clients.Group(userId).SendAsync("SendMessageUser", message.Concesionary + " - " + message.Description, 10);
            }
            return Task.CompletedTask;
        }
    }
}
