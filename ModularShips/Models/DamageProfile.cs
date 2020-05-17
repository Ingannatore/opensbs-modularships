using System.Collections.Generic;
using ModularShips.Data;

namespace ModularShips.Models
{
    public class DamageProfile
    {
        public IDictionary<DamageType, int> Damage { get; }

        public static DamageProfile Zero => new DamageProfile(0);

        public static DamageProfile Create(DamageType type, int value)
        {
            return new DamageProfile(type, value);
        }

        private DamageProfile(int value)
        {
            Damage = new Dictionary<DamageType, int>
            {
                {DamageType.Kinetic, value},
                {DamageType.Thermal, value},
                {DamageType.Electromagnetic, value},
            };
        }

        private DamageProfile(DamageType type, int value)
        {
            Damage = new Dictionary<DamageType, int> {{type, value}};
        }

        public DamageProfile AddDamage(DamageType type, int value)
        {
            if (!Damage.ContainsKey(type))
            {
                Damage.Add(type, value);
            }

            return this;
        }
    }
}
