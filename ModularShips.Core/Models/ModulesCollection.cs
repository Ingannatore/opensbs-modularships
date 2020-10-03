using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ModularShips.Core.Entities;
using ModularShips.Core.Models.Enums;
using ModularShips.Core.Modules;

namespace ModularShips.Core.Models
{
    public class ModulesCollection : IEnumerable<StarshipModule>
    {
        private readonly SortedSet<StarshipModule> _modules;
        private readonly IDictionary<Guid, StarshipModule> _modulesIndex;
        private readonly IDictionary<HullLocation, HullSection> _modulesLocation;
        private readonly IDictionary<Guid, HullLocation> _modulesLocationIndex;

        public ModulesCollection()
        {
            _modules = new SortedSet<StarshipModule>();
            _modulesIndex = new Dictionary<Guid, StarshipModule>();
            _modulesLocation = new Dictionary<HullLocation, HullSection>
            {
                {HullLocation.Bow, new HullSection()},
                {HullLocation.Amid, new HullSection()},
                {HullLocation.Stern, new HullSection()}
            };
            _modulesLocationIndex = new Dictionary<Guid, HullLocation>();
        }

        public void AddModule(StarshipModule module, HullLocation location)
        {
            _modules.Add(module);
            _modulesIndex.Add(module.Id, module);

            _modulesLocation[location].AddModule(module);
            _modulesLocationIndex.Add(module.Id, location);
        }

        public void RemoveModule(StarshipModule module)
        {
            _modules.Remove(module);
            _modulesIndex.Remove(module.Id);

            _modulesLocation[_modulesLocationIndex[module.Id]].RemoveModule(module);
            _modulesLocationIndex.Remove(module.Id);
        }

        public StarshipModule Get(Guid id)
        {
            return _modulesIndex[id];
        }

        public T Find<T>(EntitySubcategory subcategory) where T : StarshipModule
        {
            return (T) _modules.FirstOrDefault(m => m.Template.Subcategory == subcategory);
        }

        public IEnumerable<T> FindAll<T>(EntitySubcategory subcategory) where T : StarshipModule
        {
            return _modules
                .Where(m => m.Template.Subcategory == subcategory)
                .Select(m => (T) m)
                .ToList();
        }

        public void ApplyDamage(ModuleDamage damage)
        {
            if (damage.IsZero)
            {
                return;
            }

            _modulesLocation[damage.Location].ApplyDamage(damage);
        }

        public void Update(TimeSpan deltaT, Entity owner)
        {
            foreach (var module in _modules)
            {
                module.Update(deltaT, owner);
            }
        }

        public IEnumerator<StarshipModule> GetEnumerator()
        {
            return _modules.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
