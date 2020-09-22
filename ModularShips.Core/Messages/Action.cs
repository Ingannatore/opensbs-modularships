namespace ModularShips.Core.Messages
{
    public class Action
    {
        public string Type { get; }
        public object Payload { get; }

        public Action(string type, object payload = null)
        {
            Type = type;
            Payload = payload;
        }
    }
}
