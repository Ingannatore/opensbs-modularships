using ModularShips.Entities;

namespace ModularShips.Templates
{
    public abstract class ItemTemplate
    {
        public string Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public EntityCategory Category { get; protected set; }
        public EntitySubcategory Subcategory { get; protected set; }
        public EntitySize Size { get; protected set; }
        public int Mass { get; protected set; }
        public int Hitpoints { get; protected set; }
        public decimal Value { get; protected set; }
    }
}
