using ModularShips.Data;
using ModularShips.Entities;
using ModularShips.Models;

namespace ModularShips.Templates.Ammunitions.Shells
{
    public class SmallDepletedUraniumShell : AmmunitionTemplate
    {
        public SmallDepletedUraniumShell()
        {
            Id = "ammunition:shell:small:depleteduranium";
            Name = "120mm Depleted Uranium Shell";
            Description =
                "Kinetic penetrator with a depleted uranium tip, to be used as ammunition for small projectile weapons";
            Subcategory = EntitySubcategory.AmmunitionShell;
            Value = 10;

            Size = EntitySize.Small;
            Mass = 20;
            Hitpoints = 1;

            Type = AmmunitionType.Shell;
            Damage = DamagePacket.Create(10, 2, 0);
            RangeModifier = 0.5f;
        }
    }
}
