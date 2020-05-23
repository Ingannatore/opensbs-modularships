using ModularShips.Data;
using ModularShips.Entities;

namespace ModularShips.Templates.Modules
{
    public abstract class WeaponTemplate : ModuleTemplate
    {
        protected WeaponTemplate()
        {
            Subcategory = EntitySubcategory.ModuleWeapon;
        }

        public int OptimalRange { get; protected set; }
        public int MaximumRange { get; protected set; }
        public int AmmunitionPerShot { get; protected set; }
        public AmmunitionType AmmunitionType { get; protected set; }
        public int MagazineSize { get; protected set; }
        public int MagazineReloadTime { get; protected set; }
    }
}
