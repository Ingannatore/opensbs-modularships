﻿using ModularShips.Data;
using ModularShips.Entities;
using ModularShips.Models;

namespace ModularShips.Templates.Ammunitions.Shells
{
    public class SmallDepletedUraniumShell : AmmunitionTemplate
    {
        public SmallDepletedUraniumShell()
        {
            Id = "ammunition:shell:small:du";
            Name = "120mm Depleted Uranium Shell";
            Description = "Kinetic penetrator with a depleted uranium tip";
            Subcategory = EntitySubcategory.AmmunitionShell;
            Value = 10;

            Size = EntitySize.Small;
            Mass = 20;
            Hitpoints = 1;

            Type = AmmunitionType.Shell;
            Damage = Damage.Create(8, 4, 0);
        }
    }
}
