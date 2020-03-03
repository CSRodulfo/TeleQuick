using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace TeleQuick.SignalR
{
    public class NotifyHub : Hub<ITypedHubClient>
    {
        public Task BroadcastMessageUser(string userId, Message message)
        {
            return Clients.User(userId).BroadcastMessage(message.Type, "");
        }


    }
}
