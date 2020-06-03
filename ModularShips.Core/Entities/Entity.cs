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
        public Vector3 Rotation { get; set; }
        public Hull Hull { get; set; }
        public Capacity Capacitor { get; set; }
        public ICollection<Module> Modules { get; }

        public Entity(string name, Template template) : base(template)
        {
            Name = name;
            Position = Vector3.Zero;
            Rotation = Vector3.Zero;
            Modules = new List<Module>();
        }

        public Entity MoveTo(float x, float y, float z)
        {
            Position = new Vector3(x, y, z);
            return this;
        }

        public Entity RotateTo(float rx, float ry, float rz)
        {
            Rotation = new Vector3(rx, ry, rz);
            return this;
        }

        public void Update(TimeSpan deltaT)
        {
            foreach (var module in Modules)
            {
                module.Update(deltaT, this);
            }
        }

        public T GetModule<T>(EntitySubcategory subcategory) where T : Module
        {
            return (T) Modules.FirstOrDefault(m => m.Template.Subcategory == subcategory);
        }
    }
}
