using Akka.Actor;
using Behelit.ActorModel.Messages;
using Behelit.ActorModel.Messages.Commands;
using Behelit.ActorModel.Messages.Events;
using Behelit.Common.Enums;
using Behelit.Common.Interfaces;
using Behelit.Common.Models;
using System;
using System.Text.Json;

namespace Behelit.ActorModel.Actors
{
    public class SignalRActor : ReceiveActor
    {
        private readonly IActorRef _gameManager;

        private readonly ISignalREventsPusher _eventsPusher;

        public SignalRActor(IActorRef gameManager, ISignalREventsPusher eventsPusher)
        {
            _gameManager = gameManager;
            _eventsPusher = eventsPusher;

            Receive<PingMessage>((message) => HandlePingMessage(message));

            Receive<PongMessage>((message) => HandlePongMessage(message));

            Receive<PlayerCommandMessage>((message) => HandlePlayerCommandMessage(message));

            Receive<PlayerEventMessage>((message) => HandlePlayerEventMessage(message));
        }

        private void HandlePongMessage(PongMessage message)
        {
            _eventsPusher.Broadcast($"{message.Date.ToLongDateString()}: {message.Message}");
        }

        private void HandlePingMessage(PingMessage message)
        {
            _gameManager.Tell(message);
        }

        private void HandlePlayerCommandMessage(PlayerCommandMessage message)
        {
            switch (message.Command)
            {
                case nameof(PlayerCommand.Join):
                    _gameManager.Tell(new JoinGameMessage(message.Name, ""));
                    break;
                case nameof(PlayerCommand.Leave):
                    _gameManager.Tell(new LeaveGameMessage(message.Name));
                    break;
                case nameof(PlayerCommand.Move):
                    var playerDirection = JsonSerializer.Deserialize<PlayerDirection>(message.Data);
                    _gameManager.Tell(new MovePlayerMessage(message.Name, playerDirection.Direction));
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void HandlePlayerEventMessage(PlayerEventMessage message)
        {
            _eventsPusher.Broadcast(message.PlayerEvent, message.Data);
        }
    }
}
