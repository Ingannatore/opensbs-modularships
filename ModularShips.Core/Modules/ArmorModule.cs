using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public class ArmorModule : DefenseModule
    {
        public ArmorModule(Template template) : base(template) { }
        public override void Update(TimeSpan deltaT, Entity owner) { }
    }
}
