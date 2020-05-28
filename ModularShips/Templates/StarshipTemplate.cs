using System.Collections.Generic;
using System.Linq;
using ModularShips.Data;
using ModularShips.Entities;
using ModularShips.Templates.Hulls;

namespace ModularShips.Templates
{
    public abstract class StarshipTemplate : EntityTemplate
    {
        public HullTemplate HullTemplate { get; protected set; }
        public IDictionary<HullSlotType, ModuleTemplate> Modules { get; }
        public int Mass => HullTemplate?.Mass ?? 0;
        public int Hitpoints => HullTemplate?.Hitpoints ?? 1;
        public decimal Value => Modules.Values.Select(m => m.Value).Sum();

        protected StarshipTemplate()
        {
            Category = EntityCategory.Starship;
            Modules = new Dictionary<HullSlotType, ModuleTemplate>();
        }
    }
}
