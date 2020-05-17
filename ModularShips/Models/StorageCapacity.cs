namespace ModularShips.Models
{
    public class StorageCapacity : BoundedValue<int>
    {
        public StorageCapacity(int max) : base(max) { }
    }
}
