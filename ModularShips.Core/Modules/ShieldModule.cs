using System;
using System.Collections.Generic;
using ModularShips.Core.Entities;
using ModularShips.Core.Models;
using ModularShips.Core.Models.Enums;
using ModularShips.Core.Models.Interfaces;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public class ShieldModule : PoweredModule, IDamageable
    {
        public IDictionary<Direction, BoundedValue> Capacities { get; }
        public DamageResistance Resists { get; }
        public double Regeneration => Template.Shield.Regeneration * PowerFactor;

        public ShieldModule(Template template) : base(template)
        {
            Priority = 3;
            NominalPower = template.Shield.Power;
            Capacities = new Dictionary<Direction, BoundedValue>
            {
                {Direction.Ahead, new BoundedValue(template.Shield.Capacity)},
                {Direction.Starboard, new BoundedValue(template.Shield.Capacity)},
                {Direction.Astern, new BoundedValue(template.Shield.Capacity)},
                {Direction.Port, new BoundedValue(template.Shield.Capacity)}
            };
            Resists = new DamageResistance(
                template.Shield.Resists.Kinetic,
                template.Shield.Resists.Thermal,
                template.Shield.Resists.Em
            );
        }

        public Damage ApplyDamage(Damage damage, Direction direction)
        {
            if (IsDisabled)
            {
                return damage;
            }

            var mitigatedDamage = Resists.Mitigate(damage);
            var remainingDamage = Capacities[direction].Decrease(mitigatedDamage.Amount);
            return new Damage(damage.Type, remainingDamage, damage.From);
        }

        public override void OnInstall(Entity owner)
        {
            owner.Defenses.SetDefense(DefenseLayer.Shield, this);
        }

        public override void OnUninstall(Entity owner)
        {
            owner.Defenses.SetDefense(DefenseLayer.Shield, null);
        }

        public override void Update(TimeSpan deltaT, Entity owner)
        {
            base.Update(deltaT, owner);
            if (IsDisabled)
            {
                return;
            }

            foreach (var direction in (Direction[]) Enum.GetValues(typeof(Direction)))
            {
                Capacities[direction] += (int) Math.Round(Regeneration * deltaT.TotalSeconds);
            }
        }

        public override string ToString()
        {
            return
                $"[SHIELD] Capacities=<{Capacities[Direction.Ahead]} {Capacities[Direction.Starboard]} {Capacities[Direction.Astern]} {Capacities[Direction.Port]}>, Regeneration={Regeneration}, Resists={Resists}, Power={CurrentPower}/{Template.Shield.Power}";
        }
    }
}
