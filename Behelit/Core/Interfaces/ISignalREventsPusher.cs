using Behelit.Core.Enums;

namespace Behelit.Core.Interfaces
{
    public interface ISignalREventsPusher
    {
        void Broadcast(string message);

        void Broadcast(PlayerEvent playerEvent, string data);
    }
}
