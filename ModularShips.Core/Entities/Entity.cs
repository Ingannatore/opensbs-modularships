using System;
using System.Numerics;
using ModularShips.Core.Entities.Components;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Entities
{
    public class Entity : Thing
    {
        public string Name { get; }
        public BodyComponent Body { get; }
        public HullComponent Hull { get; }
        public PowergridComponent Powergrid { get; }
        public ModuleCollection Modules { get; }

        public Entity(string name, Template template) : base(template)
        {
            Name = name;
            Body = new BodyComponent(template.Structure.Mass, Vector3.Zero, Vector3.UnitX);
            Hull = new HullComponent(template.Structure.Hitpoints);
            Powergrid = new PowergridComponent();
            Modules = new ModuleCollection();
        }

        public void ApplyDamage(Damage damage)
        {
            var shield = Modules.GetShieldModule();
            if (shield != null)
            {
                damage = shield.ApplyDamage(damage);
                if (damage == null)
                {
                    return;
                }
            }

            var armor = Modules.GetArmorModule();
            if (armor != null)
            {
                damage = armor.ApplyDamage(damage);
                if (damage == null)
                {
                    return;
                }
            }

            Hull.ApplyDamage(damage);
        }

        public void Update(TimeSpan deltaT)
        {
            Powergrid.Update(deltaT, this);
            Modules.Update(deltaT, this);
            Body.Update(deltaT, this);
        }
    }
}
