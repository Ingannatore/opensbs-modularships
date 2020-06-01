﻿using ModularShips.Core.Models;
using ModularShips.Core.Templates.Elements;

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
        public decimal Value { get; set; }

        public StructureElement Structure { get; set; }
        public ActivationElement Activation { get; set; }
        public StorageElements Storage { get; set; }
        public DamageElement Damage { get; set; }

        public EngineElement Engine { get; set; }
        public SensorsElement Sensors { get; set; }
        public WeaponElement Weapon { get; set; }
        public DefenseElement Armor { get; set; }
        public DefenseElement Shield { get; set; }

        public SectionElement Slots { get; set; }
        public HardpointElement Hardpoint { get; set; }
    }
}
