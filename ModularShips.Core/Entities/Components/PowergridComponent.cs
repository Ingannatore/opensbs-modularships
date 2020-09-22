using ModularShips.Core.Modules;

namespace ModularShips.Core.Entities.Components
{
    public class PowergridComponent
    {
        private PowerplantModule _powerplant;

        public void SetPowerplant(PowerplantModule powerplant)
        {
            _powerplant = powerplant;
        }

        public bool TryConsumeEnergy(int value)
        {
            return _powerplant.TryConsumeEnergy(value);
        }
    }
}
