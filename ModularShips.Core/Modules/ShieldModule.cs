using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Entities.Interfaces;
using ModularShips.Core.Messages;
using ModularShips.Core.Models;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public class ShieldModule : StarshipModule, IDamageable
    {
        public BoundedValue Capacity { get; protected set; }
        public DamageResistance Resists { get; }

        public ShieldModule(Template template) : base(template)
        {
            PowerPriority = 3;
            Capacity = new BoundedValue(template.Shield.Capacity);
            Resists = new DamageResistance(
                template.Shield.Resists.Kinetic,
                template.Shield.Resists.Thermal,
                template.Shield.Resists.Em
            );
        }

        public Damage ApplyDamage(Damage damage)
        {
            var mitigatedDamage = Resists.Mitigate(damage);
            return new Damage(damage.Type, Capacity.Decrease(mitigatedDamage.Amount));
        }

        public override void OnInstall(Entity owner)
        {
            owner.Hull.SetDefense(DefenseLayer.Shield, this);
        }

        public override void OnUninstall(Entity owner)
        {
            owner.Hull.SetDefense(DefenseLayer.Shield, null);
        }

        public override void HandleMessage(Message message) { }

        public override void Update(TimeSpan deltaT, Entity owner)
        {
            if (Capacity.IsMax)
            {
                return;
            }

            Capacity += (int) Math.Round(Template.Shield.Regeneration * deltaT.TotalSeconds);
        }

        public override string ToString()
        {
            return $"{Capacity} [{Resists}]";
        }
    }
}
