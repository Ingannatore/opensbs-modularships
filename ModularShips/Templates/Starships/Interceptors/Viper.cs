using ModularShips.Data;
using ModularShips.Entities;

namespace ModularShips.Templates.Starships.Interceptors
{
    public class Viper : StarshipTemplate
    {
        public Viper()
        {
            Id = "starship:interceptor:viper";
            Name = "Viper-class Interceptor";
            Description = "The Viper is a fast and agile single-seater, mainly used in combat against other fighters";
            Subcategory = EntitySubcategory.StarshipInterceptor;
            Size = EntitySize.Small;
            Mass = 300000;
            Hitpoints = 500;
            Value = 100000;

            Slots[StarshipSlotType.Defense] = 2;
            Slots[StarshipSlotType.Electronics] = 1;
            Slots[StarshipSlotType.Engine] = 1;
            Slots[StarshipSlotType.Reactor] = 1;
            Slots[StarshipSlotType.Weapon] = 2;
        }
    }
}
