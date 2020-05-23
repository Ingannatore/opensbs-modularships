using ModularShips.Data;
using ModularShips.Entities;

namespace ModularShips.Templates.Modules.Reactors
{
    public class SmallFusionReactor : ReactorTemplate
    {
        public SmallFusionReactor()
        {
            Id = "reactor:small:fusion";
            Name = "1GJ Compact Fusion Reactor";
            Description = "A deuterium-deuterium fusion reactor";
            Size = EntitySize.Small;
            Hitpoints = 40;
            Mass = 500;
            Value = 15000;

            ActivationCost = -1000000;
            ActivationTime = 1;
            SingleActivation = false;

            Storage[StorageType.Energy] = 350000000;
        }
    }
}
