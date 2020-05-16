namespace ModularShips.Modules.Base
{
    public abstract class ArmourModule : Module
    {
        protected ArmourModule(string name, int hitPoints) : base(name, ModuleCategory.Armour)
        {
            AddStructure(hitPoints);
        }
    }
}
