using ModularShips.Core.Templates;

namespace ModularShips.Core.Entities
{
    public class Item : Thing
    {
        public int Quantity { get; set; }
        public int Mass => Template.Mass * Quantity;

        public Item(Template template, int quantity = 1) : base(template)
        {
            Quantity = quantity;
        }
    }
}
