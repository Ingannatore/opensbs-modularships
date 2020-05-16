using ModularShips.Data;

namespace ModularShips.Modules.Base
{
    public abstract class ReactorModule : Module
    {
        protected ReactorModule(string name, Size size, int rate) : base(name, size, ModuleCategory.Reactor)
        {
            AddEnergyProfile(rate);
        }

        protected ReactorModule(string name, Size size, int rate, int storage) : base(
            name, size, ModuleCategory.Reactor
        )
        {
            AddEnergyProfile(rate);
            AddStorage(storage, MatterState.Energy);
        }
    }
}
