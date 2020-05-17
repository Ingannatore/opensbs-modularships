using ModularShips.Data;
using ModularShips.Models;

namespace ModularShips.Modules
{
    public abstract class EngineModule : Module
    {
        public int DeltaSpeed { get; }
        public int DeltaRotation { get; }
        public Speed Speed { get; }

        protected EngineModule(string name, Size size, int deltaSpeed, int deltaRotation, int maxSpeed) : base(
            name, size, ModuleCategory.Engine
        )
        {
            DeltaSpeed = deltaSpeed;
            DeltaRotation = deltaRotation;
            Speed = new Speed(maxSpeed);
        }
    }
}
