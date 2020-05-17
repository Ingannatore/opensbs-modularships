using ModularShips.Data;
using ModularShips.Models;

namespace ModularShips.Modules.Armours
{
    public class SmallLaminatedSteelArmour : ArmourModule
    {
        public static SmallLaminatedSteelArmour Create()
        {
            return new SmallLaminatedSteelArmour();
        }

        private SmallLaminatedSteelArmour() : base(
            "100mm Laminated Steel Plating", Size.Small, 250
        )
        {
            SetDamageResistance(
                DamageProfile
                    .Create(DamageType.Electromagnetic, 50)
                    .AddDamage(DamageType.Thermal, 30)
                    .AddDamage(DamageType.Kinetic, 10)
            );
        }
    }
}
