using System;
using System.Collections.Generic;
using ModularShips.Core.Entities;
using ModularShips.Core.Messages;
using ModularShips.Core.Models;
using ModularShips.Core.Models.Interfaces;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public class ArmorModule : StarshipModule, IDamageable
    {
        public IDictionary<Direction, BoundedValue> Capacities { get; }
        public DamageResistance Resists { get; }

        public ArmorModule(Template template) : base(template)
        {
            Capacities = new Dictionary<Direction, BoundedValue>
            {
                {Direction.Ahead, new BoundedValue(template.Armor.Capacity)},
                {Direction.Starboard, new BoundedValue(template.Armor.Capacity)},
                {Direction.Astern, new BoundedValue(template.Armor.Capacity)},
                {Direction.Port, new BoundedValue(template.Armor.Capacity)}
            };
            Resists = new DamageResistance(
                template.Armor.Resists.Kinetic,
                template.Armor.Resists.Thermal,
                template.Armor.Resists.Em
            );
        }

        public Damage ApplyDamage(Damage damage, Direction direction)
        {
            var mitigatedDamage = Resists.Mitigate(damage);
            var remainingDamage = Capacities[direction].Decrease(mitigatedDamage.Amount);
            return new Damage(damage.Type, remainingDamage, damage.From);
        }

        public override void OnInstall(Entity owner)
        {
            owner.Hull.SetDefense(DefenseLayer.Armor, this);
        }

        public override void OnUninstall(Entity owner)
        {
            owner.Hull.SetDefense(DefenseLayer.Armor, null);
        }

        public override void HandleMessage(Message message) { }
        public override void Update(TimeSpan deltaT, Entity owner) { }

        public override string ToString()
        {
            return $"<{Capacities[Direction.Ahead]} {Capacities[Direction.Starboard]} {Capacities[Direction.Astern]} {Capacities[Direction.Port]}> [{Resists}]";
        }
    }
}
