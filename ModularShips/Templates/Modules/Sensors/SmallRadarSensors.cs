using ModularShips.Entities;

namespace ModularShips.Templates.Modules.Sensors
{
    public class SmallRadarSensors : SensorsTemplate
    {
        public SmallRadarSensors()
        {
            Id = "sensors:small:radar";
            Name = "2GHz Radar Array Sensors";
            Description = "A radar-based sensor array, operating in the 2GHz band";
            Size = EntitySize.Small;
            Hitpoints = 40;
            Mass = 500;
            Value = 15000;

            ActivationCost = 100000;
            ActivationTime = 1;
            SingleActivation = false;

            ScanningStrength = 10;
            TargetingRange = 5000;
            MaximumRange = 10000;
        }
    }
}
