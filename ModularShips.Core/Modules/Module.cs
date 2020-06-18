using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Models;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public abstract class Module : Thing, IComparable<Module>, IUpdatable
    {
        public bool IsActive { get; private set; }
        public int PowerPriority { get; protected set; }
        public Capacity Hitpoints { get; }

        protected Module(Template template) : base(template)
        {
            Hitpoints = new Capacity(template.Structure.Hitpoints);
        }

        public void TurnOn(Entity owner)
        {
            IsActive = owner.Power.HasBalance(Template.Power);
        }

        public void TurnOff()
        {
            IsActive = false;
        }

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

            return PowerPriority.CompareTo(other.PowerPriority);
        }

        public abstract void Update(TimeSpan deltaT, Entity owner);
    }
}
