using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ModularShips.Core.Models;
using ModularShips.Core.Modules;

namespace ModularShips.Core.Entities.Components
{
    public class ModuleCollection : IEnumerable<AStarshipModule>
    {
        private readonly SortedSet<AStarshipModule> _modules;

        public ModuleCollection()
        {
            _modules = new SortedSet<AStarshipModule>();
        }

        public void Add(AStarshipModule module, Entity owner)
        {
            _modules.Add(module);
            module.OnInstall(owner);
        }

        public T Get<T>(EntitySubcategory subcategory) where T : AStarshipModule
        {
            return (T) _modules.FirstOrDefault(m => m.Template.Subcategory == subcategory);
        }

        public IEnumerable<T> GetAll<T>(EntitySubcategory subcategory) where T : AStarshipModule
        {
            return _modules
                .Where(m => m.Template.Subcategory == subcategory)
                .Select(m => (T) m)
                .ToList();
        }

        public IEnumerator<AStarshipModule> GetEnumerator()
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
