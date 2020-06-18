using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public class WeaponModule : Module
    {
        public WeaponModule(Template template) : base(template)
        {
            PowerPriority = 4;
        }

        public override void Update(TimeSpan deltaT, Entity owner) { }
    }
}
