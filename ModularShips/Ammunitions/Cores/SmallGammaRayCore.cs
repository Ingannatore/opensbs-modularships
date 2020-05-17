using ModularShips.Data;
using ModularShips.Models;

namespace ModularShips.Ammunitions.Cores
{
    public class SmallGammaRayCore : CoreAmmunition
    {
        public SmallGammaRayCore() : base("4MSv Gamma Ray Core", Size.Small)
        {
            SetDamage(Damage.Create(0, 2, 10));
            SetRangeModifier(0.5f);
        }
    }
}
