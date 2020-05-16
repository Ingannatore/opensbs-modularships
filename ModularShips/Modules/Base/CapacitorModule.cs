using ModularShips.Data;

namespace ModularShips.Modules.Base
{
    public abstract class CapacitorModule : Module
    {
        protected CapacitorModule(string name, Size size, int storage) : base(name, size, ModuleCategory.Capacitor)
        {
            AddStorage(storage, MatterState.Energy);
        }
    }
}
