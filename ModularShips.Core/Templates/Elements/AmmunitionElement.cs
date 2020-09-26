using ModularShips.Core.Models.Enums;

namespace ModularShips.Core.Templates.Elements
{
    public class AmmunitionElement
    {
        public EntitySubcategory Type { get; set; }
        public double Reload { get; set; }
        public int Consumed { get; set; }
    }
}
