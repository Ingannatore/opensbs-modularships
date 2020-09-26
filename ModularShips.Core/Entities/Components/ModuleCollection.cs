using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ModularShips.Core.Models;
using ModularShips.Core.Modules;

namespace ModularShips.Core.Entities.Components
{
    public class ModuleCollection : IEnumerable<StarshipModule>
    {
        private readonly SortedSet<StarshipModule> _modules;
        private readonly IDictionary<Guid, StarshipModule> _modulesIndex;

        public ModuleCollection()
        {
            _modules = new SortedSet<StarshipModule>();
            _modulesIndex = new Dictionary<Guid, StarshipModule>();
        }

        public void Add(StarshipModule module, Entity owner)
        {
            _modules.Add(module);
            _modulesIndex.Add(module.Id, module);

            module.OnInstall(owner);
        }

        public T Get<T>(EntitySubcategory subcategory) where T : StarshipModule
        {
            return (T) _modules.FirstOrDefault(m => m.Template.Subcategory == subcategory);
        }

        public IEnumerable<T> GetAll<T>(EntitySubcategory subcategory) where T : StarshipModule
        {
            return _modules
                .Where(m => m.Template.Subcategory == subcategory)
                .Select(m => (T) m)
                .ToList();
        }

        public IEnumerator<StarshipModule> GetEnumerator()
        {
            return _modules.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void HandleMessage(Message message)
        {
            if (message.Recipient == MessageRecipient.Module)
            {
                _modulesIndex[message.ModuleId].HandleMessage(message);
            }
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
