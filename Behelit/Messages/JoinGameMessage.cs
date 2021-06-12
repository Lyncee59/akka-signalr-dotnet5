namespace Behelit.Messages
{
    public class JoinGameMessage
    {
        public string Name { get; private set; }

        public string Color { get; private set; }

        public JoinGameMessage(string name, string color)
        {
            Name = name;
            Color = color;
        }
    }
}
