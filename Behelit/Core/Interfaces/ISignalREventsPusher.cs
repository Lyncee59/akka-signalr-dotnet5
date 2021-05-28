namespace Behelit.Core.Interfaces
{
    public interface ISignalREventsPusher
    {
        void Broadcast(string message);
    }
}
