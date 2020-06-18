using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public class SensorsModule : Module
    {
        public SensorsModule(Template template) : base(template)
        {
            PowerPriority = 1;
        }

        public override void Update(TimeSpan deltaT, Entity owner)
        {
            //throw new NotImplementedException();
        }
    }
}
