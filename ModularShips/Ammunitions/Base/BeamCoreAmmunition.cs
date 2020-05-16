using ModularShips.Data;

namespace ModularShips.Ammunitions.Base
{
    public abstract class BeamCoreAmmunition : Ammunition
    {
        protected BeamCoreAmmunition(string name, Size size) : base(
            name, size, AmmunitionType.BeamCore
        ) { }
    }
}
