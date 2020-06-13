using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ModularShips.Core.Models;
using ModularShips.Core.Modules;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Entities
{
    public class Entity : Thing
    {
        public string Name { get; }
        public Vector3 Position { get; private set; }
        public Vector3 Direction { get; private set; }
        public Hull Hull { get; set; }
        public CapacitorModule Capacitor { get; set; }
        public ModuleCollection Modules { get; }

        public Entity(string name, Template template) : base(template)
        {
            Name = name;
            Position = Vector3.Zero;
            Direction = Vector3.UnitX;
            Modules = new ModuleCollection();
        }

        public void Update(TimeSpan deltaT)
        {
            foreach (var module in Modules)
            {
                module.Update(deltaT, this);
            }

            Capacitor.Update(deltaT, this);
        }

        public Entity SetPosition(Vector3 value)
        {
            Position = value;
            return this;
        }

        public Entity SetDirection(Vector3 value)
        {
            Direction = value;
            return this;
        }
    }
}
