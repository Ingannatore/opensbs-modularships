using ModularShips.Core.Models.Enums;

namespace ModularShips.Core.Templates
{
    public class Template
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EntityCategory Category { get; set; }
        public EntitySubcategory Subcategory { get; set; }
        public EntitySize Size { get; set; }
        public int Mass { get; set; }
        public int Hitpoints { get; set; }
        public int Value { get; set; }

        public AmmunitionTemplate Ammunition { get; set; }
        public ArmorTemplate Armor { get; set; }
        public ShieldTemplate Shield { get; set; }
        public WeaponTemplate Weapon { get; set; }
        public EngineTemplate Engine { get; set; }
        public PowerplantTemplate Powerplant { get; set; }
        public SensorsTemplate Sensors { get; set; }
        public StarshipTemplate Starship { get; set; }
    }
}
