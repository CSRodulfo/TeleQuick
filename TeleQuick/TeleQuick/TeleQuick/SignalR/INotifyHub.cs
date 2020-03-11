using System.Threading.Tasks;

namespace TeleQuick.SignalR
{
    public interface INotifyHub
    {
        Task SendMessageByUser( string description, string value);
    }
}
