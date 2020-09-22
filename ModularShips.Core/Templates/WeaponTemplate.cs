using ModularShips.Core.Templates.Elements;

namespace ModularShips.Core.Templates
{
    public class WeaponTemplate
    {
        public int Power { get; set; }
        public RangeElement Range { get; set; }
        public MagazineElement Magazine { get; set; }
        public AmmunitionElement Ammunition { get; set; }
    }
}
