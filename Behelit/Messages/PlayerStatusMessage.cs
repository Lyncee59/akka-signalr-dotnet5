namespace Behelit.Messages
{
    public class PlayerStatusMessage
    {
        public string Name { get; private set; }
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }

        public PlayerStatusMessage(string name, int positionX, int positionY)
        {
            Name = name;
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}
