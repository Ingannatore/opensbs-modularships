using ModularShips.Data;
using ModularShips.Entities;

namespace ModularShips.Templates.Hulls.UltraLight
{
    public class SmallUltraLightHullTemplate : HullTemplate
    {
        public SmallUltraLightHullTemplate()
        {
            Id = "hull:small:ultralight";
            Name = "Small Ultra-Light Starship Hull";
            Description = "An ultra-light hull for small and agile starships";
            Subcategory = EntitySubcategory.HullUltraLight;
            Size = EntitySize.Small;
            Mass = 300000;
            Hitpoints = 500;
            Value = 100000;

            Slots[HullSlotType.Defense] = 1;
            Slots[HullSlotType.Electronics] = 1;
            Slots[HullSlotType.Engine] = 1;
            Slots[HullSlotType.Reactor] = 1;
            Slots[HullSlotType.Weapon] = 2;
        }
    }
}
