using ModularShips.Data;

namespace ModularShips.Modules.Engines
{
    public class SmallIonEngine : EngineModule
    {
        public static SmallIonEngine Create()
        {
            return new SmallIonEngine();
        }

        public SmallIonEngine() : base(
            "6G Single Ion Engine", Size.Small, 60, 30, 1600
        ) { }
    }
}
