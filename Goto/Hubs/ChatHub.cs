using Microsoft.AspNetCore.SignalR;

namespace Goto.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string userId, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", userId, message);
        }
    }
}