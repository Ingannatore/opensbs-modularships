using System;
using ModularShips.Core.Modules;

namespace ModularShips.Core.Entities.Components
{
    public class PowergridComponent
    {
        public int Consumed { get; protected set; }
        public int Generated { get; protected set; }
        public int Balance { get; protected set; }

        private PowerplantModule _powerplant;

        public void SetPowerplant(PowerplantModule powerplant)
        {
            _powerplant = powerplant;
        }

        public void Reset()
        {
            Consumed = 0;
            Generated = 0;
            Balance = 0;
        }

        public bool TryConsumeEnergy(int value)
        {
            if (!_powerplant.TryConsumeEnergy(value))
            {
                return false;
            }

            Consumed += value;
            return true;
        }

        public void Update(TimeSpan deltaT)
        {
            Generated = (int) Math.Round(_powerplant.CurrentPower * deltaT.TotalSeconds);
            Balance = Generated - Consumed;
        }

        public override string ToString()
        {
            return $"[POWERGRID] Consumed={Consumed}, Generated={Generated}, Balance={Balance}";
        }
    }
}
