using System;
using System.Collections.Generic;
using System.Linq;
using ModularShips.Core.Modules;

namespace ModularShips.Core.Models
{
    public class HullSection
    {
        private readonly ICollection<StarshipModule> _modules;

        public HullSection()
        {
            _modules = new List<StarshipModule>();
        }

        public void AddModule(StarshipModule module)
        {
            _modules.Add(module);
        }

        public void RemoveModule(StarshipModule module)
        {
            _modules.Remove(module);
        }

        public void ApplyDamage(ModuleDamage damage)
        {
            var undestroyedModules = GetUndestroyedModules();
            if (!undestroyedModules.Any())
            {
                return;
            }

            SelectRandomModule(undestroyedModules).ApplyDamage(damage.Amount);
        }

        private IList<StarshipModule> GetUndestroyedModules()
        {
            return _modules.Where(m => !m.Hitpoints.IsMin).ToList();
        }

        private StarshipModule SelectRandomModule(IList<StarshipModule> modules)
        {
            var randomGenerator = new Random();
            return modules[randomGenerator.Next(modules.Count)];
        }
    }
}
