using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using TeleQuick.Helpers;

namespace TeleQuick.SignalR
{
    [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
    public class NotifyHub : Hub
    {
        private readonly HubMethods _hubMethods;

        public NotifyHub(IHubContext<NotifyHub> hubContext)
        {
            _hubMethods = new HubMethods(hubContext);
        }

        public Task SendMessageUser(string userId, Message message)
        {
            return _hubMethods.WriteMessageAsync(userId,  message );
        }

        public Task SendMessageToGroups(string userId, Message message)
        {
            return Clients.Group(userId).SendAsync("SendMessageUser", message.Description, message.Value);
        }

        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, Utilities.GetUserId(Context.User));
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, Utilities.GetUserId(Context.User));
            await base.OnDisconnectedAsync(exception);
        }


    }
    public class NameUserIdProvider : IUserIdProvider
    {
        public virtual string GetUserId(HubConnectionContext connection)
        {
            return connection.User?.Identity?.Name;
        }
    }
}

