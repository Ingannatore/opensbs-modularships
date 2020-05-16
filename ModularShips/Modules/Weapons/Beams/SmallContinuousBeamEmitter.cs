using ModularShips.Data;
using ModularShips.Modules.Base;

namespace ModularShips.Modules.Weapons.Beams
{
    public class SmallContinuousBeamEmitter : WeaponModule
    {
        public SmallContinuousBeamEmitter(Orientation orientation) : base(
            "8MJ Continuous Beam Emitter", Size.Small, orientation
        )
        {
            SetShotProfile(8, 4);
            SetAmmunitionProfile(Data.AmmunitionType.BeamCore, 0);
            SetRange(Range.Short);
        }
    }
}
