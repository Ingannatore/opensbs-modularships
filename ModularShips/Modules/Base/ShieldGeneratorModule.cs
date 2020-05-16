using ModularShips.Data;

namespace ModularShips.Modules.Base
{
    public abstract class ShieldGeneratorModule : Module
    {
        public int RechargeRate { get; }
        public HitPoints Capacity { get; }

        protected ShieldGeneratorModule(string name, Size size, int rechargeRate, int capacity) : base(
            name, size, ModuleCategory.ShieldGenerator
        )
        {
            RechargeRate = rechargeRate;
            Capacity = new HitPoints(capacity);
        }
    }
}
