using System.Numerics;
using ModularShips.Core.Models.Enums;

namespace ModularShips.Core.Models
{
    public class Damage
    {
        public DamageType Type { get; }
        public int Amount { get; }
        public Vector3? From { get; }
        public bool IsZero => Amount == 0;
        public bool IsDirectional => From.HasValue;

        public Damage(DamageType type, int amount, Vector3? from = null)
        {
            Type = type;
            Amount = amount;
            From = from;
        }

        public static Damage operator +(Damage a, int b) => new Damage(a.Type, a.Amount + b, a.From);
        public static Damage operator -(Damage a, int b) => new Damage(a.Type, a.Amount - b, a.From);
    }
}
