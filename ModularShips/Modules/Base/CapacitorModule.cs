namespace ModularShips.Modules.Base
{
    public abstract class CapacitorModule : Module
    {
        protected CapacitorModule(string name, int storage) : base(name, ModuleCategory.Capacitor)
        {
            AddStorage(storage, StorageType.Energy);
        }
    }
}
