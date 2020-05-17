using ModularShips.Data;
using ModularShips.Models;

namespace ModularShips.Ammunitions.Projectiles
{
    public class SmallDepletedUraniumProjectile : ProjectileAmmunition
    {
        public SmallDepletedUraniumProjectile() : base("120mm Depleted Uranium Shell", Size.Small)
        {
            SetDamage(Damage.Create(8, 2, 0));
            SetRangeModifier(0.75f);
        }
    }
}
