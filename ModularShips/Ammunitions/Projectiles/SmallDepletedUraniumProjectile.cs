using ModularShips.Data;
using ModularShips.Models;

namespace ModularShips.Ammunitions.Projectiles
{
    public class SmallDepletedUraniumProjectile : ProjectileAmmunition
    {
        public SmallDepletedUraniumProjectile() : base("120mm Depleted Uranium Shell", Size.Small)
        {
            SetDamageProfile(DamageProfile
                .Create(DamageType.Kinetic, 8)
                .AddDamage(DamageType.Thermal, 2)
            );
            SetRangeModifier(0.75f);
        }
    }
}
