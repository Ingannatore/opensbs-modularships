using ModularShips.Entities;
using ModularShips.Models;

namespace ModularShips.Templates.Modules.Armors
{
    public class SmallSteelAlloyArmor : DefenseTemplate
    {
        public SmallSteelAlloyArmor()
        {
            Id = "armor:small:steelalloy";
            Name = "100mm Laminated Steel Plating";
            Description = "A laminated steel alloy plating, reinforced with molybdenum";
            Size = EntitySize.Small;
            Hitpoints = 80;
            Mass = 10000;
            Value = 5000;

            ArmorCapacity = DefenseCapacity.Create(220);
            Resistances = DamageResistances.Create(0.2f, 0.3f, 0.5f);
        }
    }
}
