using Behelit.Common.Enums;

namespace Behelit.ActorModel.Messages
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
