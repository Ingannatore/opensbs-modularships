using System;
using System.Collections.Generic;
using ModularShips.Core.Entities.Interfaces;

namespace ModularShips.Core.Entities.Components
{
    public class StructureComponent : IUpdatable
    {
        private readonly Queue<Damage> _damages;

        public StructureComponent()
        {
            _damages = new Queue<Damage>();
        }

        public void EnqueueDamage(Damage damage)
        {
            _damages.Enqueue(damage);
        }

        public void Update(TimeSpan deltaT, Entity owner)
        {
            while (_damages.TryDequeue(out var damage))
            {
                ApplyDamage(damage, owner);
            }
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

            owner.Hull.ApplyDamage(damage);
        }
    }
}
