using System.Collections.Generic;
using ModularShips.Data;
using ModularShips.Entities;

namespace ModularShips.Templates.Hulls
{
    public abstract class HullTemplate : ItemTemplate
    {
        public IDictionary<HullSlotType, int> Slots { get; }

        protected HullTemplate()
        {
            Category = EntityCategory.Hull;
            Slots = new Dictionary<HullSlotType, int>();
        }
    }
}
