using System;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Entities
{
    public abstract class Module : Thing
    {
        protected Module(Template template) : base(template) { }

        public abstract void Update(TimeSpan deltaT, Entity owner);
    }
}
