using ModularShips.Data;

namespace ModularShips.Modules.Base
{
    public abstract class ArmourModule : Module
    {
        protected ArmourModule(string name, Size size, int hitPoints) : base(name, size, ModuleCategory.Armour)
        {
            AddStructure(hitPoints);
        }
    }
}
