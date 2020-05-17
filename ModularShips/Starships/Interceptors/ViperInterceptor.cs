using ModularShips.Data;
using ModularShips.Models;
using ModularShips.Modules.Armours;
using ModularShips.Modules.Engines;
using ModularShips.Modules.Reactors;
using ModularShips.Modules.Sensors;
using ModularShips.Modules.Shields;
using ModularShips.Modules.Weapons.Beams;

namespace ModularShips.Starships.Interceptors
{
    public class ViperInterceptor : Starship
    {
        public ViperInterceptor(string name) : base(
            name, "Viper", StarshipCategory.Interceptor, 1
        )
        {
            InstallHull(Hull.Small);

            AddHullSection(
                HullSection.AllAround,
                SmallRadarSensors.Create(),
                SmallFusionReactor.Create(),
                SmallIonEngine.Create(),
                SmallStaticShield.Create(),
                SmallLaminatedSteelArmour.Create(),
                SmallContinuousBeamEmitter.Create(Orientation.QuarterFront),
                SmallContinuousBeamEmitter.Create(Orientation.QuarterFront)
            );
        }
    }
}
