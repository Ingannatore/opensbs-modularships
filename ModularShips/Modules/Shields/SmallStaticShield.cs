using ModularShips.Data;
using ModularShips.Models;

namespace ModularShips.Modules.Shields
{
    public class SmallStaticShield : ShieldModule
    {
        public static SmallStaticShield Create()
        {
            return new SmallStaticShield();
        }

        public SmallStaticShield() : base(
            "4MT Static Shield Generator", Size.Small, 10, 200
        )
        {
            AddEnergyProfile(-4);
            SetDamageResistance(
                DamageProfile
                    .Create(DamageType.Electromagnetic, 10)
                    .AddDamage(DamageType.Thermal, 30)
                    .AddDamage(DamageType.Kinetic, 50)
            );
        }
    }
}
