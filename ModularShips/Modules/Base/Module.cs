using System;

namespace ModularShips.Modules.Base
{
    public abstract class Module
    {
        public Guid Id { get; }
        public string Name { get; }
        public ModuleCategory Category { get; }
        public HitPoints HitPoints { get; protected set; }
        public EnergyUsage EnergyUsage { get; protected set; }
        public Storage Storage { get; protected set; }

        protected Module(string name, ModuleCategory category)
        {
            Id = Guid.NewGuid();
            Name = name;
            Category = category;
        }

        protected void AddStructure(int maxHitPoints)
        {
            HitPoints = new HitPoints(maxHitPoints);
        }

        protected void AddEnergyProfile(int energyRate)
        {
            EnergyUsage = new EnergyUsage(energyRate);
        }

        protected void AddStorage(int quantity, StorageType type)
        {
            Storage = new Storage(quantity, type);
        }
    }
}
