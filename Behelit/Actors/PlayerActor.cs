
using Akka.Actor;
using Behelit.Core.Enums;
using Behelit.Messages;
using Behelit.Messages.Commands;
using System;

namespace Behelit.Actors
{
    public class PlayerActor : ReceiveActor
    {
        public string Name { get; private set; }
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }

        public PlayerActor(string name)
        {
            Name = name;
            PositionX = 0;
            PositionY = 0;

            Receive<MovePlayerMessage>((message) => HandleMovePlayerMessage(message));

            Receive<RefreshPlayerStatusMessage>((message) => HandleRefreshPlayerStatusMessage(message));
        }

        private void HandleMovePlayerMessage(MovePlayerMessage message)
        {
            switch(message.Direction)
            {
                case MoveDirection.Up:
                    PositionY++;
                    break;
                case MoveDirection.Down:
                    PositionY--;
                    break;
                case MoveDirection.Left:
                    PositionX--;
                    break;
                case MoveDirection.Right:
                    PositionY++;
                    break;
            }

            Sender.Tell(new PlayerStatusMessage(Name, PositionX, PositionY));
        }

        private void HandleRefreshPlayerStatusMessage(RefreshPlayerStatusMessage message)
        {
            Sender.Tell(new PlayerStatusMessage(Name, PositionX, PositionY));
        }
    }
}
