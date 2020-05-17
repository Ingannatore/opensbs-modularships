using ModularShips.Data;
using ModularShips.Models;

namespace ModularShips.Modules
{
    public abstract class ShieldModule : Module
    {
        public int RechargeRate { get; }
        public HitPoints Capacity { get; }
        public Resistance Resistance { get; protected set; }

        protected ShieldModule(string name, Size size, int rechargeRate, int capacity) : base(
            name, size, ModuleCategory.Shield
        )
        {
            RechargeRate = rechargeRate;
            Capacity = new HitPoints(capacity);
        }

        protected void SetResistance(Resistance resistance)
        {
            Resistance = resistance;
        }
    }
}
