using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public class ShieldModule : Module
    {
        public ShieldModule(Template template) : base(template) { }

        public override void Update(TimeSpan deltaT, Entity owner)
        {
            throw new NotImplementedException();
        }
    }
}
