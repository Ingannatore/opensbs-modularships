using ModularShips.Data;

namespace ModularShips.Modules.Base
{
    public abstract class SublightEngineModule : Module
    {
        public int DeltaV { get; }
        public Speed Speed { get; }

        protected SublightEngineModule(string name, Size size, int deltaV, Speed speed) : base(
            name, size, ModuleCategory.SublightEngine
        )
        {
            DeltaV = deltaV;
            Speed = speed;
        }
    }
}
