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

        private readonly StructureComponent _structure;

        public Entity(string name, Template template) : base(template)
        {
            Name = name;
            Body = new BodyComponent(template.Structure.Mass, Vector3.Zero, Vector3.UnitX);
            Hull = new HullComponent(template.Structure.Hitpoints);
            _structure = new StructureComponent();
            Powergrid = new PowergridComponent();
            Modules = new ModuleCollection();
        }

        public void ApplyDamage(Damage damage)
        {
            _structure.EnqueueDamage(damage);
        }

        public void Update(TimeSpan deltaT)
        {
            _structure.Update(deltaT, this);
            Powergrid.Update(deltaT, this);
            Modules.Update(deltaT, this);
            Body.Update(deltaT, this);
        }
    }
}
