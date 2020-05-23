using ModularShips.Data;
using ModularShips.Entities;

namespace ModularShips.Templates.Modules.Weapons
{
    public class SmallMonoEmitterBeam : WeaponTemplate
    {
        public SmallMonoEmitterBeam()
        {
            Id = "weapon:beam:small:monoemitter";
            Name = "8MJ Mono-Emitter Beam";
            Description = "A single-emitter beam weapon, optimized for narrow-band wavelengths";
            Size = EntitySize.Small;
            Hitpoints = 40;
            Mass = 500;
            Value = 10000;

            ActivationCost = 100000;
            ActivationTime = 4;
            SingleActivation = false;

            OptimalRange = 1000;
            MaximumRange = 2000;

            AmmunitionPerShot = 0;
            AmmunitionType = AmmunitionType.Core;
            MagazineSize = 1;
            MagazineReloadTime = 30;
        }
    }
}
