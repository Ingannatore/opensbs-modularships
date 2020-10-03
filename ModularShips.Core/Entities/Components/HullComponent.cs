using System;
using System.Collections.Generic;
using ModularShips.Core.Models;
using ModularShips.Core.Models.Enums;
using ModularShips.Core.Modules;

namespace ModularShips.Core.Entities.Components
{
    public class HullComponent
    {
        public BoundedValue Hitpoints { get; private set; }
        public bool IsDestroyed => Hitpoints.Current <= 0;
        public ModulesCollection Modules { get; }

        public HullComponent(int hitpoints)
        {
            Hitpoints = new BoundedValue(hitpoints);
            Modules = new ModulesCollection();
        }

        public void InstallModule(StarshipModule module, HullLocation location)
        {
            Modules.AddModule(module, location);
        }

        public T GetModule<T>(EntitySubcategory subcategory) where T : StarshipModule
        {
            return Modules.Find<T>(subcategory);
        }

        public IEnumerable<T> GetModules<T>(EntitySubcategory subcategory) where T : StarshipModule
        {
            return Modules.FindAll<T>(subcategory);
        }

        public void ApplyDamage(Damage damage, Direction direction)
        {
            if (damage.IsZero)
            {
                return;
            }

            var moduleDamage = new ModuleDamage(damage.Amount, Hitpoints.Current, direction);
            Hitpoints -= damage.Amount;
            Modules.ApplyDamage(moduleDamage);
        }

        public void HandleModuleMessage(Message message)
        {
            Modules.Get(message.ModuleId).HandleMessage(message);
        }

        public void Update(TimeSpan deltaT, Entity owner)
        {
            Modules.Update(deltaT, owner);
        }

        public override string ToString()
        {
            return $"[HULL] HP={Hitpoints}, Destroyed={IsDestroyed}";
        }
    }
}
