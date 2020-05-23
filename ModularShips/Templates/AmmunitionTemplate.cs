using ModularShips.Data;
using ModularShips.Entities;
using ModularShips.Models;

namespace ModularShips.Templates
{
    public abstract class AmmunitionTemplate : ItemTemplate
    {
        protected AmmunitionTemplate()
        {
            Category = EntityCategory.Ammunition;
        }

        public AmmunitionType Type { get; protected set; }
        public DamagePacket Damage { get; protected set; }
        public float RangeModifier { get; protected set; }
    }
}
