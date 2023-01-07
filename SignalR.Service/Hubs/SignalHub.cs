using Microsoft.AspNetCore.SignalR;
using SignalR.Service.Interfaces;
using SignalR.Service.Models;

namespace SignalR.Service.Hubs
{
    public class SignalHub : Hub<IChatClient>
    {
        public override Task OnConnectedAsync()
        {
            return Task.CompletedTask;
        }

        public async Task SendMessage(ChatMessage message)
        {
            await Clients.All.ReceiveMessage(message);
        }
    }
}
