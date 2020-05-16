using System;
using ModularShips.Data;

namespace ModularShips.Ammunitions.Base
{
    public abstract class Ammunition
    {
        public Guid Id { get; }
        public string Name { get; }
        public Size Size { get; }
        public AmmunitionType Type { get; }
        public DamageProfile Damage { get; protected set; }
        public float RangeModifier { get; protected set; }

        protected Ammunition(string name, Size size, AmmunitionType type)
        {
            Id = Guid.NewGuid();
            Name = name;
            Size = size;
            Type = type;
            RangeModifier = 1;
        }

        protected void SetDamageProfile(DamageProfile damage)
        {
            Damage = damage;
        }

        protected void SetRangeModifier(float rangeModifier)
        {
            RangeModifier = rangeModifier;
        }
    }
}
