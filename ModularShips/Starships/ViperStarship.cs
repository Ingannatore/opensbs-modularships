using ModularShips.Data;
using ModularShips.Modules;
using ModularShips.Modules.Base;
using ModularShips.Starships.Base;

namespace ModularShips.Starships
{
    public class ViperStarship : Starship
    {
        public ViperStarship(string name) : base(name, "Viper", StarshipCategory.Interceptor, 1)
        {
            InstallHull(Hull.Small);

            AddHullSection(
                HullSection.AllAround,
                SensorsModule.Create(10, Range.Medium),
                ReactorModule.Create(10, 350),
                SublightEngineModule.Create(-4, 150, 1500),
                ShieldGenerator.Create(-4, 10, 200),
                ArmourModule.Create(350),
                WeaponModule.Create(20, 4, Range.Short, Orientation.QuarterFront),
                WeaponModule.Create(20, 4, Range.Short, Orientation.QuarterFront)
            );
        }
    }
}
