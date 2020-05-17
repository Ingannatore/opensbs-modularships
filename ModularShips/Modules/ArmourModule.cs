using ModularShips.Data;
using ModularShips.Models;

namespace ModularShips.Modules
{
    public abstract class ArmourModule : Module
    {
        public Resistance Resistance { get; protected set; }

        protected ArmourModule(string name, Size size, int hitPoints) : base(name, size, ModuleCategory.Armour)
        {
            AddStructure(hitPoints);
        }

        protected void SetResistance(Resistance resistance)
        {
            Resistance = resistance;
        }
    }
}
