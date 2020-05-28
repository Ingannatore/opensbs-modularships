using ModularShips.Data;
using ModularShips.Entities;
using ModularShips.Models;

namespace ModularShips.Templates.Ammunitions.Cores
{
    public class SmallGammaRayCore : AmmunitionTemplate
    {
        public SmallGammaRayCore()
        {
            Id = "ammunition:core:small:gammaray";
            Name = "4MSv Gamma Ray Core";
            Description = "Gamma ray emitter core to be used in small beam weapons";
            Subcategory = EntitySubcategory.AmmunitionCore;
            Value = 10;

            Size = EntitySize.Small;
            Mass = 20;
            Hitpoints = 1;

            Type = AmmunitionType.Core;
            Damage = Damage.Create(0, 2, 10);
        }
    }
}
