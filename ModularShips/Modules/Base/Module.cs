using System;
using System.Collections.Generic;
using ModularShips.Data;

namespace ModularShips.Modules.Base
{
    public abstract class Module
    {
        public Guid Id { get; }
        public string Name { get; }
        public Size Size { get; }
        public ModuleCategory Category { get; }
        public HitPoints HitPoints { get; protected set; }
        public EnergyUsage EnergyUsage { get; protected set; }
        public IDictionary<MatterState, StorageCapacity> Storage { get; }

        protected Module(string name, Size size, ModuleCategory category)
        {
            Id = Guid.NewGuid();
            Name = name;
            Size = size;
            Category = category;
            Storage = new Dictionary<MatterState, StorageCapacity>();
        }

        protected void AddStructure(int maxHitPoints)
        {
            HitPoints = new HitPoints(maxHitPoints);
        }

        protected void AddEnergyProfile(int energyRate)
        {
            EnergyUsage = new EnergyUsage(energyRate);
        }

        protected void AddStorage(MatterState type, int capacity)
        {
            if (!Storage.ContainsKey(type))
            {
                Storage.Add(type, new StorageCapacity(capacity));
            }
        }
    }
}
