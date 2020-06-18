using System;

namespace ModularShips.Core.Entities.Components
{
    public class PowerComponent : IUpdatable
    {
        public double Generated { get; protected set; }
        public double Used { get; protected set; }
        public double Balance { get; protected set; }

        public bool HasBalance(double value)
        {
            if (value > 0)
            {
                return true;
            }

            return Balance >= Math.Abs(value);
        }

        public void Update(TimeSpan deltaT, Entity owner)
        {
            Generated = 0;
            Used = 0;
            Balance = 0;

            foreach (var module in owner.Modules)
            {
                if (!module.IsActive)
                {
                    continue;
                }

                var modulePower = module.Template.Power;
                if (modulePower >= 0)
                {
                    Generated += modulePower;
                    Balance += modulePower;
                    continue;
                }

                if (Balance >= Math.Abs(modulePower))
                {
                    Used += Math.Abs(modulePower);
                    Balance += modulePower;
                    continue;
                }

                if (module.IsActive)
                {
                    module.TurnOff();
                }
            }
        }

        public override string ToString()
        {
            return FormattableString.Invariant($"{Used:0.000}/{Generated:0.000} ({Balance:+0.000})");
        }
    }
}
