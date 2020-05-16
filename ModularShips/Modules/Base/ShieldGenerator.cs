namespace ModularShips.Modules.Base
{
    public abstract class ShieldGenerator : Module
    {
        public int RechargeRate { get; }
        public HitPoints Capacity { get; }

        protected ShieldGenerator(string name, int rechargeRate, int capacity) : base(name, ModuleCategory.ShieldGenerator)
        {
            RechargeRate = rechargeRate;
            Capacity = new HitPoints(capacity);
        }
    }
}
