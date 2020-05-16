using ModularShips.Ammunitions.Base;
using ModularShips.Data;

namespace ModularShips.Ammunitions.BeamCores
{
    public class SmallGammaRayCore : BeamCoreAmmunition
    {
        public SmallGammaRayCore() : base("4MSv Gamma Ray Core", Size.Small)
        {
            SetDamageProfile(DamageProfile
                .Create(DamageType.Electromagnetic, 8)
                .AddDamage(DamageType.Thermal, 4)
            );
            SetRangeModifier(0.5f);
        }
    }
}
