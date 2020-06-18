using System;
using System.Numerics;
using ModularShips.Core.Entities.Components;
using ModularShips.Core.Modules;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Entities
{
    public class Entity : Thing
    {
        public string Name { get; }
        public BodyComponent Body { get; }
        public HullComponent HullComponent { get; set; }
        public PowerComponent Power { get; }
        public ModuleCollection Modules { get; }

        public Entity(string name, Template template) : base(template)
        {
            Name = name;
            Body = new BodyComponent(Vector3.Zero, Vector3.UnitX);
            Power = new PowerComponent();
            Modules = new ModuleCollection();
        }

        public void Update(TimeSpan deltaT)
        {
            Power.Update(deltaT, this);
            Modules.Update(deltaT, this);
            Body.Update(deltaT, this);
        }
    }
}
