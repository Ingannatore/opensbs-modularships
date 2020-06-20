using System;
using System.Collections.Generic;
using ModularShips.Core.Models;

namespace ModularShips.Core.Entities
{
    public class DamageResistance
    {
        private readonly IDictionary<DamageType, float> _values;
        public float Kinetic => _values[DamageType.Kinetic];
        public float Thermal => _values[DamageType.Thermal];
        public float Electromagnetic => _values[DamageType.Electromagnetic];

        public DamageResistance(float kinetic, float thermal, float em)
        {
            _values = new Dictionary<DamageType, float>
            {
                {DamageType.Kinetic, kinetic},
                {DamageType.Thermal, thermal},
                {DamageType.Electromagnetic, em},
            };
        }

        public Damage Mitigate(Damage damage)
        {
            return new Damage(
                damage.Type,
                (int) Math.Round(damage.Amount * (1 - _values[DamageType.Thermal]))
            );
        }

        public override string ToString()
        {
            return FormattableString
                .Invariant($"Kin {Kinetic:0.00}, The {Thermal:0.00}, Em {Electromagnetic:0.00}");
        }
    }
}
