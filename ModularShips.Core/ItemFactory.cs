using ModularShips.Core.Entities;
using ModularShips.Core.Templates;

namespace ModularShips.Core
{
    public static class ItemFactory
    {
        public static Item Create(Template template, int quantity = 1)
        {
            return new Item(template, quantity);
        }
    }
}
