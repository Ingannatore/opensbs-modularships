using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Models;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public abstract class Module : Thing, IUpdatable
    {
        public Capacity Hitpoints { get; }

        protected Module(Template template) : base(template)
        {
            Hitpoints = new Capacity(template.Structure.Hitpoints);
        }

        public abstract void Update(TimeSpan deltaT, Entity owner);
    }
}
