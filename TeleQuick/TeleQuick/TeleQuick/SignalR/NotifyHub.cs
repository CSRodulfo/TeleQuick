using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace TeleQuick.SignalR
{
    public class NotifyHub : Hub
    {
        private readonly HubMethods _hubMethods;

        public NotifyHub(IHubContext<NotifyHub> hubContext)
        {
            _hubMethods = new HubMethods(hubContext);
        }

        public Task SendMessageUser(string userId, Message message)
        {
            return _hubMethods.WriteMessageAsync("SendMessageUser", message );
        }

        public Task SendMessageToGroups(string userId, Message message)
        {
            return Clients.Group(userId).SendAsync("SendMessageUser", message.Description, message.Value);
        }

        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }


    }
}

