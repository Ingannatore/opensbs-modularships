using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Models;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public abstract class Module : Thing, IComparable<Module>, IUpdatable
    {
        public int Priority { get; protected set; }
        public Capacity Hitpoints { get; }

        protected Module(Template template) : base(template)
        {
            Hitpoints = new Capacity(template.Structure.Hitpoints);
        }

        public abstract void Update(TimeSpan deltaT, Entity owner);

        public int CompareTo(Module other)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            if (ReferenceEquals(null, other))
            {
                return 1;
            }

            return Priority.CompareTo(other.Priority);
        }
    }
}
