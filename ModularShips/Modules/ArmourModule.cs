using ModularShips.Data;
using ModularShips.Models;

namespace ModularShips.Modules
{
    public abstract class ArmourModule : Module
    {
        public DamageProfile DamageResistance { get; protected set; }

        protected ArmourModule(string name, Size size, int hitPoints) : base(name, size, ModuleCategory.Armour)
        {
            AddStructure(hitPoints);
        }

        protected void SetDamageResistance(DamageProfile damageResistance)
        {
            DamageResistance = damageResistance;
        }
    }
}
