using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Entities.Interfaces;
using ModularShips.Core.Messages;
using ModularShips.Core.Models;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public class ArmorModule : StarshipModule, IDamageable
    {
        public DamageResistance Resists { get; }

        public ArmorModule(Template template) : base(template)
        {
            Resists = new DamageResistance(
                template.Armor.Resists.Kinetic,
                template.Armor.Resists.Thermal,
                template.Armor.Resists.Em
            );
        }

        public Damage ApplyDamage(Damage damage)
        {
            var mitigatedDamage = Resists.Mitigate(damage);
            return new Damage(damage.Type, Hitpoints.Decrease(mitigatedDamage.Amount));
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
            return $"{Hitpoints} [{Resists}]";
        }
    }
}
