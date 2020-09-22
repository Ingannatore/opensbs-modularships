using System.Collections.Generic;
using ModularShips.Core.Templates.Elements;

namespace ModularShips.Core.Templates
{
    public class StarshipTemplate : Template
    {
        public IList<SlotElement> Slots { get; set; }

        public StarshipTemplate()
        {
            Slots = new List<SlotElement>();
        }
    }
}
