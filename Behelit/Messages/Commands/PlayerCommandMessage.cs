namespace Behelit.Messages.Commands
{
    public class PlayerCommandMessage
    {
        public string Name { get; private set; }

        public string Command { get; private set; }

        public string Data { get; private set; }

        public PlayerCommandMessage(string name, string command, string data)
        {
            Name = name;
            Command = command;
            Data = data;
        }
    }
}
