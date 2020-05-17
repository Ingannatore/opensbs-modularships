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
            SetResistance(Resistance.Create(0.5f, 0.3f, 0.1f));
        }
    }
}
