namespace Behelit.ActorModel.Messages
{
    public class LeaveGameMessage
    {
        public string Name { get; private set; }

        public LeaveGameMessage(string name)
        {
            Name = name;
        }
    }
}
