using System.Threading.Tasks;

namespace TeleQuick.SignalR
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(string type, string payload);
    }
}
