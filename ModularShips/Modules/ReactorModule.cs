using ModularShips.Data;

namespace ModularShips.Modules
{
    public abstract class ReactorModule : Module
    {
        protected ReactorModule(string name, Size size, int energyRate) : base(name, size, ModuleCategory.Reactor)
        {
            AddEnergyProfile(energyRate);
        }

        protected ReactorModule(string name, Size size, int energyRate, int capacity) : base(
            name, size, ModuleCategory.Reactor
        )
        {
            AddEnergyProfile(energyRate);
            AddStorage(MatterState.Energy, capacity);
        }
    }
}
