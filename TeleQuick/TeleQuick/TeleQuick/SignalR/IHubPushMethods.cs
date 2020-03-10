using System.Threading.Tasks;

namespace TeleQuick.SignalR
{
    public interface IHubPushMethods
    {
        Task Connected(string username);

        Task Disconnected(string username);

        Task SendMessageByUser( string description, string value);
    }
}
