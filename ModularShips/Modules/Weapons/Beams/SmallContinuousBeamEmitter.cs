using ModularShips.Data;
using ModularShips.Models;

namespace ModularShips.Modules.Weapons.Beams
{
    public class SmallContinuousBeamEmitter : WeaponModule
    {
        public static SmallContinuousBeamEmitter Create(Orientation orientation)
        {
            return new SmallContinuousBeamEmitter(orientation);
        }

        private SmallContinuousBeamEmitter(Orientation orientation) : base(
            "8MJ Continuous Beam Emitter", Size.Small, orientation
        )
        {
            SetShotProfile(8, 4);
            SetAmmunitionProfile(Data.AmmunitionType.Core, 0);
            SetRange(Range.Short);
        }
    }
}
