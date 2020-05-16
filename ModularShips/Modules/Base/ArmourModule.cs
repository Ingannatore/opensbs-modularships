using ModularShips.Data;

namespace ModularShips.Modules.Base
{
    public abstract class ArmourModule : Module
    {
        public DamageProfile DamageResistance { get; }

        protected ArmourModule(string name, Size size, int hitPoints) : base(name, size, ModuleCategory.Armour)
        {
            AddStructure(hitPoints);
            DamageResistance = DamageProfile.Zero;
        }

        protected ArmourModule(string name, Size size, int hitPoints, DamageProfile damageResistance) : base(
            name, size, ModuleCategory.Armour
        )
        {
            AddStructure(hitPoints);
            DamageResistance = damageResistance;
        }
    }
}
