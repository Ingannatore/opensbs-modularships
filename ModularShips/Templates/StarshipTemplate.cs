using System.Collections.Generic;
using ModularShips.Data;
using ModularShips.Entities;

namespace ModularShips.Templates
{
    public abstract class StarshipTemplate : ItemTemplate
    {
        protected StarshipTemplate()
        {
            Category = EntityCategory.Starship;
            Slots = new Dictionary<StarshipSlotType, int>();
        }

        public IDictionary<StarshipSlotType, int> Slots { get; }
    }
}
