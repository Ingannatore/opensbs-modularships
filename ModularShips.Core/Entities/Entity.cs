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
        public Vector3 Position { get; set; }
        public Vector3 Direction { get; set; }
        public Hull Hull { get; set; }
        public CapacitorModule Capacitor { get; set; }
        public ICollection<Module> Modules { get; }

        public Entity(string name, Template template) : base(template)
        {
            Name = name;
            Position = Vector3.Zero;
            Direction = Vector3.UnitX;
            Modules = new List<Module>();
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

        public T GetModule<T>(EntitySubcategory subcategory) where T : Module
        {
            return (T) Modules.FirstOrDefault(m => m.Template.Subcategory == subcategory);
        }

        public IEnumerable<T> GetModules<T>(EntitySubcategory subcategory) where T : Module
        {
            return Modules
                .Where(m => m.Template.Subcategory == subcategory)
                .Select(m => (T)m)
                .ToList();
        }
    }
}
