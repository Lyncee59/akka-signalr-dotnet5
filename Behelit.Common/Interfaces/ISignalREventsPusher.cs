using Behelit.Common.Enums;

namespace Behelit.Common.Interfaces
{
    public interface ISignalREventsPusher
    {
        void Broadcast(string message);

        void Broadcast(PlayerEvent playerEvent, string data);
    }
}
