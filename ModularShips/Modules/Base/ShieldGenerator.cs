using ModularShips.Data;

namespace ModularShips.Modules.Base
{
    public abstract class ShieldGenerator : Module
    {
        public int RechargeRate { get; }
        public HitPoints Capacity { get; }

        protected ShieldGenerator(string name, Size size, int rechargeRate, int capacity) : base(
            name, size, ModuleCategory.ShieldGenerator
        )
        {
            RechargeRate = rechargeRate;
            Capacity = new HitPoints(capacity);
        }
    }
}
