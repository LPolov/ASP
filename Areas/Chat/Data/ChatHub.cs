using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace OnlineShop.Areas.Chat.Data
{
    /*
     * This class is used as a hub which takes messages from user and sends it to all users
     * connected to this server.
     */
    public class ChatHub : Hub
    {
        public async Task Send(string userName, string message)
        {
            await Clients.All.SendAsync("Receive", userName, message ); 
        }
    }
}