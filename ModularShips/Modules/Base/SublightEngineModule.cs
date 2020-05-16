namespace ModularShips.Modules.Base
{
    public abstract class SublightEngineModule : Module
    {
        public int DeltaV { get; }
        public Speed Speed { get; }

        protected SublightEngineModule(string name, int deltaV, Speed speed) : base(name, ModuleCategory.SublightEngine)
        {
            DeltaV = deltaV;
            Speed = speed;
        }
    }
}
