using ModularShips.Data;

namespace ModularShips.Modules.Base
{
    public abstract class ShieldGeneratorModule : Module
    {
        public int RechargeRate { get; }
        public HitPoints Capacity { get; }
        public DamageProfile DamageResistance { get; }

        protected ShieldGeneratorModule(string name, Size size, int rechargeRate, int capacity) : base(
            name, size, ModuleCategory.ShieldGenerator
        )
        {
            RechargeRate = rechargeRate;
            Capacity = new HitPoints(capacity);
            DamageResistance = DamageProfile.Zero;
        }

        protected ShieldGeneratorModule(
            string name, Size size, int rechargeRate, int capacity, DamageProfile damageResistance
        ) : base(
            name, size, ModuleCategory.ShieldGenerator
        )
        {
            RechargeRate = rechargeRate;
            Capacity = new HitPoints(capacity);
            DamageResistance = damageResistance;
        }
    }
}
