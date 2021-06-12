using Akka.Actor;
using Behelit.Core;
using Behelit.Messages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Behelit.Actors
{
    public class GameManagerActor: ReceiveActor
    {
        private readonly IRandomService _randomService;
        private readonly IServiceScope _scope;

        private readonly Dictionary<string, IActorRef> _players;

        public GameManagerActor(IServiceProvider sp)
        {
            _scope = sp.CreateScope();
            _randomService = _scope.ServiceProvider.GetRequiredService<IRandomService>();
            _players = new Dictionary<string, IActorRef>();

            Receive<PingMessage>((message) => HandlePingMessage());

            Receive<MovePlayerMessage>((message) => HandleMovePlayerMessage(message));

            Receive<JoinGameMessage>((message) => HandleJoinGameMessage(message));

            Receive<LeaveGameMessage>((message) => HandleLeaveGameMessage(message));
        }

        private void HandlePingMessage()
        {
            var randomString = _randomService.GenerateRandomString();

            var pongMessage = new PongMessage(randomString);

            Sender.Tell(pongMessage);
        }

        private void HandleMovePlayerMessage(MovePlayerMessage message)
        {
            var doesPlayerExist = _players.ContainsKey(message.Name);

            if (doesPlayerExist)
            {
                _players[message.Name].Tell(message, Sender);
            }
        }

        private void HandleJoinGameMessage(JoinGameMessage message)
        {
            var doesPlayerExist = _players.ContainsKey(message.Name);

            if (!doesPlayerExist)
            {
                var newPlayerActor = Context.ActorOf(Props.Create(() => new PlayerActor(message.Name)));
                _players.Add(message.Name, newPlayerActor);

                foreach (var player in _players.Values)
                {
                    player.Tell(new RefreshPlayerStatusMessage(), Sender);
                }
            }
        }

        private void HandleLeaveGameMessage(LeaveGameMessage message)
        {
            var doesPlayerExist = _players.ContainsKey(message.Name);

            if (doesPlayerExist)
            {
                _players[message.Name].Tell(PoisonPill.Instance, Sender);
            }
        }
    }
}
