using System;
using System.Collections.Generic;
using ModularShips.Core.Models;
using ModularShips.Core.Models.Interfaces;

namespace ModularShips.Core.Entities.Components
{
    public class HullComponent
    {
        public BoundedValue Hitpoints { get; private set; }
        public bool IsDestroyed => Hitpoints.Current <= 0;

        private readonly IDictionary<DefenseLayer, IDamageable> _defenses;

        public HullComponent(int hitpoints)
        {
            Hitpoints = new BoundedValue(hitpoints);
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

        public void ApplyDamage(Damage damage)
        {
            foreach (var direction in (Direction[]) Enum.GetValues(typeof(Direction)))
            {
                ApplyDamage(damage, direction);
            }
        }

        public void ApplyDamage(Damage damage, Direction direction)
        {
            if (_defenses.ContainsKey(DefenseLayer.Shield))
            {
                damage = _defenses[DefenseLayer.Shield].ApplyDamage(damage, direction);
            }

            if (_defenses.ContainsKey(DefenseLayer.Armor))
            {
                damage = _defenses[DefenseLayer.Armor].ApplyDamage(damage, direction);
            }

            Hitpoints -= damage.Amount;
        }

        public override string ToString()
        {
            return $"[HULL] HP={Hitpoints}, Destroyed={IsDestroyed}";
        }
    }
}
