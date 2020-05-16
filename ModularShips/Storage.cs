using ModularShips.Data;

namespace ModularShips
{
    public class Storage
    {
        public int Quantity { get; }
        public MatterState Type { get; }

        public Storage(int quantity, MatterState type)
        {
            Quantity = quantity;
            Type = type;
        }
    }
}
