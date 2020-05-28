using ModularShips.Data;
using ModularShips.Entities;
using ModularShips.Models;

namespace ModularShips.Templates.Ammunitions.Shells
{
    public class SmallTungstenShell : AmmunitionTemplate
    {
        public SmallTungstenShell()
        {
            Id = "ammunition:shell:small:tungsten";
            Name = "120mm Tungsten Shell";
            Description = "Kinetic penetrator with a Tungsten tip";
            Subcategory = EntitySubcategory.AmmunitionShell;
            Value = 10;

            Size = EntitySize.Small;
            Mass = 20;
            Hitpoints = 1;

            Type = AmmunitionType.Shell;
            Damage = Damage.Create(12, 0, 0);
        }
    }
}
