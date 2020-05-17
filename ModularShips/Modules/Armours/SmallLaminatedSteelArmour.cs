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
            SetResistance(Resistance.Create(0.1f, 0.3f, 0.5f));
        }
    }
}
