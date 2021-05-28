using Akka.Actor;
using Behelit.ActorModel.ExternalSystems;
using Behelit.ActorModel.Messages;

namespace Behelit.ActorModel.Actors
{
    public class SignalRBridgeActor : ReceiveActor
    {
        private readonly IGameEventsPusher _gameEventsPusher;

        private readonly IActorRef _gameController;

        public SignalRBridgeActor(IGameEventsPusher gameEventsPusher, IActorRef gameController)
        {
            _gameEventsPusher = gameEventsPusher;
            _gameController = gameController;

            Receive<JoinGameMessage>(message => HandleJoinGameMessage(message));

            Receive<AttackPlayerMessage>(message => HandleAttackPlayerMessage(message));

            Receive<PlayerStatusMessage>(message => HandlePlayerStatusMessage(message));

            Receive<PlayerHealthChangedMessage>(message => HandlePlayerHealthChangedMessage(message));
        }


        private void HandleJoinGameMessage(JoinGameMessage message)
        {
            _gameController.Tell(message);
        }

        private void HandleAttackPlayerMessage(AttackPlayerMessage message)
        {
            _gameController.Tell(message);
        }

        private void HandlePlayerStatusMessage(PlayerStatusMessage message)
        {
            _gameEventsPusher.PlayerJoined(message.PlayerName, message.Health);
        }

        private void HandlePlayerHealthChangedMessage(PlayerHealthChangedMessage message)
        {
            _gameEventsPusher.UpdatePlayerHealth(message.PlayerName, message.Health);
        }
    }
}
