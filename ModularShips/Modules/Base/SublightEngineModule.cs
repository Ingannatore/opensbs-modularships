using ModularShips.Data;

namespace ModularShips.Modules.Base
{
    public abstract class SublightEngineModule : Module
    {
        public int DeltaSpeed { get; }
        public int DeltaRotation { get; }
        public Speed Speed { get; }

        protected SublightEngineModule(string name, Size size, int deltaSpeed, int deltaRotation, int maxSpeed) : base(
            name, size, ModuleCategory.SublightEngine
        )
        {
            DeltaSpeed = deltaSpeed;
            DeltaRotation = deltaRotation;
            Speed = new Speed(maxSpeed);
        }
    }
}
