using Behelit.Core.Enums;

namespace Behelit.Messages
{
    public class MovePlayerMessage
    {
        public string Name;
        public MoveDirection Direction;

        public MovePlayerMessage(string name, MoveDirection direction)
        {
            Name = name;
            Direction = direction;
        }
    }
}
