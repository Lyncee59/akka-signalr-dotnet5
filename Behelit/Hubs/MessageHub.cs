using Behelit.Core.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System;

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
            Console.WriteLine("Ping !!!!!!!!");
            _processor.Ping();
        }
    }
}
