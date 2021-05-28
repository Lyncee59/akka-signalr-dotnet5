using Akka.Actor;
using Behelit.ActorModel.Messages;
using System;
using System.Collections.Generic;

namespace Behelit.ActorModel.Actors
{
    public class GameControllerActor: ReceiveActor
    {
        private readonly Dictionary<string, IActorRef> _players;

        public GameControllerActor()
        {
            _players = new Dictionary<string, IActorRef>();

            Receive<JoinGameMessage>(message => HandleJoinGameMessage(message));

            Receive<AttackPlayerMessage>(message => HandleAttackPlayerMessage(message));
        }

        private void HandleJoinGameMessage(JoinGameMessage message)
        {
            var doesPlayerExist = !_players.ContainsKey(message.PlayerName);

            if (doesPlayerExist)
            {
                var newPlayerActor = Context.ActorOf(Props.Create(() => new PlayerActor(message.PlayerName)));
                _players.Add(message.PlayerName, newPlayerActor);

                foreach(var player in _players.Values)
                {
                    player.Tell(new RefreshPlayerStatusMessage(), Sender);
                }
            }
        }
        private void HandleAttackPlayerMessage(AttackPlayerMessage message)
        {
            _players[message.PlayerName].Forward(message);
        }

    }
}
