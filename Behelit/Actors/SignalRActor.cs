using Akka.Actor;
using Behelit.Core.Interfaces;
using Behelit.Messages;
using System;

namespace Behelit.Actors
{
    public class SignalRActor : ReceiveActor
    {
        private readonly IActorRef _gameManager;

        private readonly ISignalREventsPusher _eventsPusher;

        public SignalRActor(IActorRef gameManager, ISignalREventsPusher eventsPusher)
        {
            _gameManager = gameManager;
            _eventsPusher = eventsPusher;

            Receive<string>((message) => HandleString(message));

            Receive<PingMessage>((message) => HandlePingMessage(message));

            Receive<PongMessage>((message) => HandlePongMessage(message));
        }

        private void HandlePongMessage(PongMessage message)
        {
            _eventsPusher.Broadcast($"{message.Date.ToLongDateString()}: {message.Message}");
        }

        private void HandlePingMessage(PingMessage message)
        {
            _gameManager.Tell(message);
        }

        private void HandleString(string message)
        {
            throw new NotImplementedException();
        }
    }
}
