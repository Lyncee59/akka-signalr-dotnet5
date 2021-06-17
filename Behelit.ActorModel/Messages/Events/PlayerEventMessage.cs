using Behelit.Common.Enums;

namespace Behelit.ActorModel.Messages.Events
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
