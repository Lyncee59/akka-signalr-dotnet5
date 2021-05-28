using Akka.Actor;
using Behelit.ActorModel.Messages;
using System;

namespace Behelit.ActorModel.Actors
{
    public class PlayerActor: ReceiveActor
    {
        private readonly string _playerName;

        private int _health;

        public PlayerActor(string playerName)
        {
            _playerName = playerName;
            _health = 100;

            Receive<AttackPlayerMessage>(message => HandleAttackPlayerMessage(message));

            Receive<RefreshPlayerStatusMessage>(message => HandleRefreshPlayerStatusMessage(message));
        }

        private void HandleAttackPlayerMessage(AttackPlayerMessage message)
        {
            _health -= 20;
            Sender.Tell(new PlayerHealthChangedMessage(_playerName, _health));
        }
        private void HandleRefreshPlayerStatusMessage(RefreshPlayerStatusMessage message)
        {
            Sender.Tell(new PlayerStatusMessage(_playerName, _health));
        }

    }
}
