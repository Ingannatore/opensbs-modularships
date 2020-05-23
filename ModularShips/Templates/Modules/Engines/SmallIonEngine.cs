using ModularShips.Entities;

namespace ModularShips.Templates.Modules.Engines
{
    public class SmallIonEngine : EngineTemplate
    {
        public SmallIonEngine()
        {
            Id = "engine:small:ion";
            Name = "6G Ion Engine";
            Description = "A single-nozzle ion engine that uses Xenon gas as fuel";
            Size = EntitySize.Small;
            Hitpoints = 40;
            Mass = 500;
            Value = 15000;

            ActivationCost = 500000;
            ActivationTime = 1;
            SingleActivation = false;

            Acceleration = 80;
            MaximumSpeed = 1600;
            RotationSpeed = 10;
        }
    }
}
