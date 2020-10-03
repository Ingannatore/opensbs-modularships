using System.Collections.Generic;
using ModularShips.Core.Models;
using ModularShips.Core.Models.Enums;
using ModularShips.Core.Models.Interfaces;

namespace ModularShips.Core.Entities.Components
{
    public class DefensesComponent
    {
        private readonly IDictionary<DefenseLayer, IDamageable> _defenses;

        public DefensesComponent()
        {
            _defenses = new Dictionary<DefenseLayer, IDamageable>();
        }

        public void SetDefense(DefenseLayer layer, IDamageable defense)
        {
            if (defense == null)
            {
                _defenses.Remove(layer);
            }
            else
            {
                _defenses[layer] = defense;
            }
        }

        public Damage ApplyDamage(Damage damage, Direction direction)
        {
            if (_defenses.ContainsKey(DefenseLayer.Shield))
            {
                damage = _defenses[DefenseLayer.Shield].ApplyDamage(damage, direction);
            }

            if (_defenses.ContainsKey(DefenseLayer.Armor))
            {
                damage = _defenses[DefenseLayer.Armor].ApplyDamage(damage, direction);
            }

            return damage;
        }
    }
}
