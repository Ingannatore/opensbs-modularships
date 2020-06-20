using System;
using ModularShips.Core.Entities.Interfaces;
using ModularShips.Core.Models;

namespace ModularShips.Core.Entities.Components
{
    public class HullComponent : IDamageable
    {
        public BoundedValue Hitpoints { get; protected set; }
        public bool IsDestroyed => Hitpoints.Current <= 0;

        public HullComponent(int hitpoints)
        {
            Hitpoints = new BoundedValue(hitpoints);
        }

        public Damage ApplyDamage(Damage damage)
        {
            Hitpoints -= damage.Amount;
            return null;
        }

        public override string ToString()
        {
            return Hitpoints.ToString();
        }
    }
}
