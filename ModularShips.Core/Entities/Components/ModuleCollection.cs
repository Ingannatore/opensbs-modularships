using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ModularShips.Core.Entities.Interfaces;
using ModularShips.Core.Models;
using ModularShips.Core.Modules;

namespace ModularShips.Core.Entities.Components
{
    public class ModuleCollection : IEnumerable<Module>, IUpdatable
    {
        private readonly SortedSet<Module> _modules;
        private ShieldModule _shield;
        private ArmorModule _armor;

        public ModuleCollection()
        {
            _modules = new SortedSet<Module>();
        }

        public void Add(Module module)
        {
            _modules.Add(module);

            switch (module.Template.Subcategory)
            {
                case EntitySubcategory.ModuleShield:
                    _shield = (ShieldModule) module;
                    break;
                case EntitySubcategory.ModuleArmor:
                    _armor = (ArmorModule) module;
                    break;
            }
        }

        public ShieldModule GetShieldModule()
        {
            return _shield;
        }

        public ArmorModule GetArmorModule()
        {
            return _armor;
        }

        public T Get<T>(EntitySubcategory subcategory) where T : Module
        {
            return (T) _modules.FirstOrDefault(m => m.Template.Subcategory == subcategory);
        }

        public IEnumerable<T> GetAll<T>(EntitySubcategory subcategory) where T : Module
        {
            return _modules
                .Where(m => m.Template.Subcategory == subcategory)
                .Select(m => (T) m)
                .ToList();
        }

        public IEnumerator<Module> GetEnumerator()
        {
            return _modules.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Update(TimeSpan deltaT, Entity owner)
        {
            foreach (var module in _modules)
            {
                module.Update(deltaT, owner);
            }
        }
    }
}
