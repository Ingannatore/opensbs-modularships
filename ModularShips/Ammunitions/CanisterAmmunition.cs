using ModularShips.Data;

namespace ModularShips.Ammunitions
{
    public class CanisterAmmunition : Ammunition
    {
        public CanisterAmmunition(string name, Size size) : base(
            name, size, AmmunitionType.Canister
        ) { }
    }
}
