using Behelit.Core.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Behelit.Hubs
{
    public class MessageHub: Hub
    {
        private readonly ISignalRProcessor _processor;

        public MessageHub(ISignalRProcessor processor)
        {
            _processor = processor;
        }

        public void Ping()
        {
            _processor.Ping();
        }

        public void SendPlayerCommand(string playerName, string command, string data)
        {
            _processor.SendPlayerCommand(playerName, command, data);
        }
    }
}
