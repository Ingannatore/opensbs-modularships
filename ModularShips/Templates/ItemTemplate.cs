namespace ModularShips.Templates
{
    public abstract class ItemTemplate : EntityTemplate
    {
        public int Mass { get; protected set; }
        public int Hitpoints { get; protected set; }
        public decimal Value { get; protected set; }
    }
}
