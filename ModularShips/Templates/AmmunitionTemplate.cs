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
        public Damage Damage { get; protected set; }
    }
}
