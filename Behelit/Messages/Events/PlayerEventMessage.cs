using Behelit.Core.Enums;

namespace Behelit.Messages.Commands
{
    public class PlayerEventMessage
    {
        public PlayerEvent PlayerEvent { get; private set; }
        
        public string Data { get; private set; }

        public PlayerEventMessage(PlayerEvent playerEvent, string data)
        {
            PlayerEvent = playerEvent;
            Data = data;
        }
    }
}
