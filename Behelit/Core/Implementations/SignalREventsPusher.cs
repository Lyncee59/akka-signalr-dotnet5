using Behelit.Core.Interfaces;
using Behelit.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
