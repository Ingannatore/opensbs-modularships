using ModularShips.Core.Models;

namespace ModularShips.Core.Entities
{
    public class Damage
    {
        public DamageType Type { get; }
        public int Amount { get; }
        public bool IsZero => Amount == 0;

        public Damage(DamageType type, int amount)
        {
            Type = type;
            Amount = amount;
        }

        public static Damage operator +(Damage a, int b) => new Damage(a.Type, a.Amount + b);
        public static Damage operator -(Damage a, int b) => new Damage(a.Type, a.Amount - b);
    }
}
