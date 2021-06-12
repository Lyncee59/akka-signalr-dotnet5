using Behelit.Core.Enums;
using Behelit.Core.Interfaces;
using Behelit.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Behelit.Core.Implementations
{
    public class SignalREventsPusher: ISignalREventsPusher
    {
        private readonly IHubContext<MessageHub> _hub;

        public SignalREventsPusher(IHubContext<MessageHub> hub)
        {
            _hub = hub;
        }

        public void Broadcast(string message)
        {
            _hub.Clients.All.SendAsync("broadcast", message);
        }

        public void Broadcast(PlayerEvent playerEvent, string data)
        {
            _hub.Clients.All.SendAsync(nameof(playerEvent), data);
        }
    }
}
