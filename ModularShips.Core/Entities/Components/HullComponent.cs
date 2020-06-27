using System;
using System.Collections.Generic;
using ModularShips.Core.Entities.Interfaces;
using ModularShips.Core.Models;

namespace ModularShips.Core.Entities.Components
{
    public class HullComponent : IUpdatable, IDamageable
    {
        public BoundedValue Hitpoints { get; protected set; }
        public bool IsDestroyed { get; protected set; }

        private readonly Queue<Damage> _damages;

        public HullComponent(int hitpoints)
        {
            Hitpoints = new BoundedValue(hitpoints);
            _damages = new Queue<Damage>();
        }

        public Damage ApplyDamage(Damage damage)
        {
            _damages.Enqueue(damage);
            return null;
        }

        public void Update(TimeSpan deltaT, Entity owner)
        {
            while (_damages.TryDequeue(out var damage))
            {
                ApplyDamage(damage, owner);
            }

            IsDestroyed = Hitpoints.Current <= 0;
        }

        public override string ToString()
        {
            return Hitpoints.ToString();
        }

        private void ApplyDamage(Damage damage, Entity owner)
        {
            var shield = owner.Modules.GetShieldModule();
            if (shield != null)
            {
                damage = shield.ApplyDamage(damage);
                if (damage == null)
                {
                    return;
                }
            }

            var armor = owner.Modules.GetArmorModule();
            if (armor != null)
            {
                damage = armor.ApplyDamage(damage);
                if (damage == null)
                {
                    return;
                }
            }

            Hitpoints -= damage.Amount;
        }
    }
}
