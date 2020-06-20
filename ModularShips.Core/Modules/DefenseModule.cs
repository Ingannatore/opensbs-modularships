using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Entities.Interfaces;
using ModularShips.Core.Models;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public abstract class DefenseModule : Module, IDamageable
    {
        public BoundedValue Capacity { get; protected set; }
        public DamageResistance Resists { get; }

        protected DefenseModule(Template template) : base(template)
        {
            Capacity = new BoundedValue(template.Defense.Hitpoints);
            Resists = new DamageResistance(
                template.Defense.Resists.Kinetic,
                template.Defense.Resists.Thermal,
                template.Defense.Resists.Em
            );
        }

        public Damage ApplyDamage(Damage damage)
        {
            if (!IsActive)
            {
                return damage;
            }

            damage = Resists.Mitigate(damage);
            var remainingDamage = Capacity.Current >= damage.Amount
                ? null
                : new Damage(
                    damage.Type,
                    damage.Amount - Capacity.Current
                );

            Capacity -= damage.Amount;
            return remainingDamage;
        }

        public override string ToString()
        {
            return $"{Capacity} [{Resists}]";
        }
    }
}
