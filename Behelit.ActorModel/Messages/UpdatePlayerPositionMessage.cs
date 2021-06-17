using Behelit.Common.Models;

namespace Behelit.ActorModel.Messages
{
    public class UpdatePlayerPositionMessage
    {
        public string Name { get; private set; }
        public PlayerPosition Position { get; private set; }

        public UpdatePlayerPositionMessage(string name, PlayerPosition position)
        {
            Name = name;
            Position = position;
        }
    }
}
