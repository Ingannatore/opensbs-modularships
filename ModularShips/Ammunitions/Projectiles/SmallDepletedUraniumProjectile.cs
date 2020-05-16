using ModularShips.Ammunitions.Base;
using ModularShips.Data;

namespace ModularShips.Ammunitions.Projectiles
{
    public class SmallDepletedUraniumProjectile : ProjectileAmmunition
    {
        public SmallDepletedUraniumProjectile() : base("200mm Depleted Uranium Shell", Size.Small)
        {
            SetDamageProfile(DamageProfile
                .Create(DamageType.Kinetic, 8)
                .AddDamage(DamageType.Thermal, 2)
            );
            SetRangeModifier(0.75f);
        }
    }
}
