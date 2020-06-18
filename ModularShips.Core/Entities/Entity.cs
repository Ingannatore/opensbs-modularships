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
        public Hull Hull { get; set; }
        public CapacitorModule Capacitor { get; set; }
        public ModuleCollection Modules { get; }

        public Entity(string name, Template template) : base(template)
        {
            Name = name;
            Body = new BodyComponent(Vector3.Zero,Vector3.UnitX);
            Modules = new ModuleCollection();
        }

        public void Update(TimeSpan deltaT)
        {
            Body.Update(deltaT, this);

            foreach (var module in Modules)
            {
                module.Update(deltaT, this);
            }

            // Capacitor.Update(deltaT, this);
        }
    }
}
