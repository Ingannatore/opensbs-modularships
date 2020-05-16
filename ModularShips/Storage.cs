namespace ModularShips
{
    public class Storage
    {
        public int Quantity { get; }
        public StorageType Type { get; }

        public Storage(int quantity, StorageType type)
        {
            Quantity = quantity;
            Type = type;
        }
    }
}
