using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace TeleQuick.SignalR
{
    public class NotifyHub : Hub<IHubPushMethods> , IHubInvokeMethods
    {
        IHubContext<NotifyHub> _context;
        public NotifyHub(IHubContext<NotifyHub> context)
        {
            this._context = context;
        }

        public Task SendMessageUser(string userId, Message message)
        {
            return _context.Clients.User(userId).SendAsync("SendMessageUser", message.Description, message.Value);
        }


    }
}

