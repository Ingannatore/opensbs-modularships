using ModularShips.Data;

namespace ModularShips.Modules.Reactors
{
    public class SmallFusionReactor : ReactorModule
    {
        public static SmallFusionReactor Create()
        {
            return new SmallFusionReactor();
        }

        private SmallFusionReactor() : base(
            "10GJ Deuterium Fusion Reactor", Size.Small, 10, 350
        ) { }
    }
}
