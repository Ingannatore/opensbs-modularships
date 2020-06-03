using System.Collections.Generic;
using ModularShips.Core.Models;
using ModularShips.Core.Templates.Elements;

namespace ModularShips.Core.Modules
{
    public class Hull
    {
        public int Mass { get; }
        public Capacity Hitpoints { get; }
        public IDictionary<DamageType, float> Resists { get; }

        public Hull(StructureElement structure)
        {
            Mass = structure?.Mass ?? 0;
            Hitpoints = new Capacity(structure?.Hitpoints ?? 0);
            Resists = new Dictionary<DamageType, float>
            {
                {DamageType.Kinetic, 0},
                {DamageType.Thermal, 0},
                {DamageType.Electromagnetic, 0}
            };
        }
    }
}
