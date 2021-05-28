using System;

namespace Behelit.Messages
{
    public class PongMessage
    {
        public DateTime Date { get; private set; }

        public string Message { get; private set; }

        public PongMessage(string message)
        {
            Date = DateTime.Now;
            Message = message;
        }
    }
}
