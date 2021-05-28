namespace Behelit.Core.Interfaces
{
    public interface ISignalRProcessor
    {
        void Ping();
        void Deliver(string message);
    }
}
