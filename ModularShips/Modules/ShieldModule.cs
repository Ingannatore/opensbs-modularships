using ModularShips.Data;
using ModularShips.Models;

namespace ModularShips.Modules
{
    public abstract class ShieldModule : Module
    {
        public int RechargeRate { get; }
        public HitPoints Capacity { get; }
        public DamageProfile DamageResistance { get; protected set; }

        protected ShieldModule(string name, Size size, int rechargeRate, int capacity) : base(
            name, size, ModuleCategory.Shield
        )
        {
            RechargeRate = rechargeRate;
            Capacity = new HitPoints(capacity);
        }

        protected void SetDamageResistance(DamageProfile damageResistance)
        {
            DamageResistance = damageResistance;
        }
    }
}
