namespace ModularShips.Modules.Base
{
    public abstract class SensorsModule : Module
    {
        public int Strength { get; }
        public Range Range { get; }

        protected SensorsModule(string name, int strength, Range range) : base(name, ModuleCategory.Sensors)
        {
            Strength = strength;
            Range = range;
        }
    }
}
