using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public class ShieldModule : DefenseModule
    {
        public int Regeneration { get; }

        public ShieldModule(Template template) : base(template)
        {
            PowerPriority = 3;
            Regeneration = template.Defense.Hitpoints / 10;
        }

        public override void Update(TimeSpan deltaT, Entity owner)
        {
            if (Capacity.IsMax || !IsActive)
            {
                return;
            }

            Capacity += (int)Math.Round(Regeneration * deltaT.TotalSeconds);
        }

        public override string ToString()
        {
            return $"{base.ToString()} [{Regeneration:+0}] [{IsActive}]";
        }
    }
}
