using SignalR.Service.Models;

namespace SignalR.Service.Interfaces
{
    public interface IChatClient
    {
        Task ReceiveMessage(ChatMessage message);
    }
}
