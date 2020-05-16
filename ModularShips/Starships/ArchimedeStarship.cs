using ModularShips.Data;
using ModularShips.Modules;
using ModularShips.Modules.Base;
using ModularShips.Starships.Base;

namespace ModularShips.Starships
{
    public class ArchimedeStarship : Starship
    {
        public ArchimedeStarship(string name) : base(name, "Archimede", StarshipCategory.Cruiser, 3)
        {
            InstallHull(Hull.Medium);

            AddHullSection(
                HullSection.HalfFront,
                ArmourModule.Create(350),
                ShieldGeneratorModule.Create(-4, 10, 200),
                WeaponModule.Create(20, 4, Range.Short, Orientation.QuarterFront),
                WeaponModule.Create(20, 4, Range.Short, Orientation.QuarterFront)
            );

            AddHullSection(
                HullSection.HalfRear,
                ArmourModule.Create(350),
                ReactorModule.Create(10, 350),
                SublightEngineModule.Create(-4, 150, 1500),
                ShieldGeneratorModule.Create(-4, 10, 200),
                SensorsModule.Create(10, Range.Medium)
            );
        }
    }
}
