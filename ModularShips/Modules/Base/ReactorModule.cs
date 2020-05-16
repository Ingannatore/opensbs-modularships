namespace ModularShips.Modules.Base
{
    public abstract class ReactorModule : Module
    {
        protected ReactorModule(string name, int rate, int storage) : base(name, ModuleCategory.Reactor)
        {
            AddEnergyProfile(rate);
            AddStorage(storage, StorageType.Energy);
        }
    }
}
