using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public class PowerplantModule : Module
    {
        public PowerplantModule(Template template) : base(template)
        {
            PowerPriority = 0;
        }

        public override void Update(TimeSpan deltaT, Entity owner) { }
    }
}
