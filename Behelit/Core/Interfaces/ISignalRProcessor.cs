namespace Behelit.Core.Interfaces
{
    public interface ISignalRProcessor
    {
        void Ping();
        void SendPlayerCommand(string playerName, string command, string data);
    }
}
