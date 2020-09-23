using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Entities.Interfaces;
using ModularShips.Core.Models;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public class ShieldModule : APoweredModule, IDamageable
    {
        public BoundedValue Capacity { get; protected set; }
        public DamageResistance Resists { get; }
        public double Regeneration => Template.Shield.Regeneration * PowerFactor;

        public ShieldModule(Template template) : base(template)
        {
            Priority = 3;
            NominalPower = template.Shield.Power;
            Capacity = new BoundedValue(template.Shield.Capacity);
            Resists = new DamageResistance(
                template.Shield.Resists.Kinetic,
                template.Shield.Resists.Thermal,
                template.Shield.Resists.Em
            );
        }

        public Damage ApplyDamage(Damage damage)
        {
            if (IsDisabled)
            {
                return damage;
            }

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

        public override void Update(TimeSpan deltaT, Entity owner)
        {
            base.Update(deltaT, owner);
            if (IsDisabled || Capacity.IsMax)
            {
                return;
            }

            Capacity += (int) Math.Round(Regeneration * deltaT.TotalSeconds);
        }

        public override string ToString()
        {
            return $"[SHIELD] Capacity={Capacity}, Regeneration={Regeneration}, Resists={Resists}, Power={CurrentPower}/{Template.Shield.Power}";
        }
    }
}
