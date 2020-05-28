using ModularShips.Entities;

namespace ModularShips.Templates
{
    public abstract class EntityTemplate
    {
        public string Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public EntityCategory Category { get; protected set; }
        public EntitySubcategory Subcategory { get; protected set; }
        public EntitySize Size { get; protected set; }
    }
}
