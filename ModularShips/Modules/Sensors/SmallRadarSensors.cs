using ModularShips.Data;
using ModularShips.Models;

namespace ModularShips.Modules.Sensors
{
    public class SmallRadarSensors : SensorsModule
    {
        public static SmallRadarSensors Create()
        {
            return new SmallRadarSensors();
        }

        private SmallRadarSensors() : base(
            "Medium-range Radar Sensor Array", Size.Small, 10, Range.Medium
        ) { }
    }
}
