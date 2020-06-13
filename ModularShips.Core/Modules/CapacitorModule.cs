using System;
using ModularShips.Core.Entities;

namespace ModularShips.Core.Modules
{
    public class CapacitorModule : IUpdatable
    {
        public int TotalCapacity { get; }
        public int StoredEnergy { get; private set; }
        public int EnergyBalance { get; private set; }
        private int _deltaEnergy;

        public CapacitorModule(int capacity)
        {
            TotalCapacity = StoredEnergy = capacity;
        }

        public void AddEnergy(int value)
        {
            _deltaEnergy += value;
        }

        public bool ConsumeEnergy(int value)
        {
            if (!HasEnergy(value))
            {
                return false;
            }

            _deltaEnergy += value;
            return true;
        }

        public void Update(TimeSpan deltaT, Entity owner)
        {
            StoredEnergy = Math.Max(0, Math.Min(TotalCapacity, StoredEnergy + _deltaEnergy));
            EnergyBalance = _deltaEnergy * (1000 / deltaT.Milliseconds);
            _deltaEnergy = 0;
        }

        public override string ToString()
        {
            return $"{StoredEnergy}/{TotalCapacity} ({EnergyBalance:+#;-#;0})";
        }

        private bool HasEnergy(int value)
        {
            return StoredEnergy + _deltaEnergy >= Math.Abs(value);
        }
    }
}
