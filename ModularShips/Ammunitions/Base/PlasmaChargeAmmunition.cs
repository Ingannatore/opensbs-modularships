using ModularShips.Data;

namespace ModularShips.Ammunitions.Base
{
    public class PlasmaChargeAmmunition : Ammunition
    {
        public PlasmaChargeAmmunition(string name, Size size) : base(
            name, size, AmmunitionType.PlasmaCharge
        ) { }
    }
}
