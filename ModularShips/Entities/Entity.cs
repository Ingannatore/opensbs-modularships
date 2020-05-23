using System;

namespace ModularShips.Entities
{
    public abstract class Entity
    {
        protected Entity(string name, EntitySize size)
        {
            Id = Guid.NewGuid();
            Name = name;
            Size = size;
        }

        public Guid Id { get; }
        public string Name { get; }
        public EntitySize Size { get; }
    }
}
