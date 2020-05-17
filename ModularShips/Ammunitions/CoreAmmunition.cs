using ModularShips.Data;

namespace ModularShips.Ammunitions
{
    public abstract class CoreAmmunition : Ammunition
    {
        protected CoreAmmunition(string name, Size size) : base(
            name, size, AmmunitionType.Core
        ) { }
    }
}
