using ModularShips.Data;
using ModularShips.Models;

namespace ModularShips.Ammunitions.Cores
{
    public class SmallGammaRayCore : CoreAmmunition
    {
        public SmallGammaRayCore() : base("4MSv Gamma Ray Core", Size.Small)
        {
            SetDamageProfile(DamageProfile
                .Create(DamageType.Electromagnetic, 10)
                .AddDamage(DamageType.Thermal, 2)
            );
            SetRangeModifier(0.5f);
        }
    }
}
