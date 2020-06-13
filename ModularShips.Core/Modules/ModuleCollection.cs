using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ModularShips.Core.Models;

namespace ModularShips.Core.Modules
{
    public class ModuleCollection : IEnumerable<Module>
    {
        private readonly SortedSet<Module> _modules;

        public ModuleCollection()
        {
            _modules = new SortedSet<Module>();
        }

        public void Add(Module module)
        {
            _modules.Add(module);
        }

        public T Get<T>(EntitySubcategory subcategory) where T : Module
        {
            return (T) _modules.FirstOrDefault(m => m.Template.Subcategory == subcategory);
        }

        public IEnumerable<T> GetAll<T>(EntitySubcategory subcategory) where T : Module
        {
            return _modules
                .Where(m => m.Template.Subcategory == subcategory)
                .Select(m => (T)m)
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
    }
}
