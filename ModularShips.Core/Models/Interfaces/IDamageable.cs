using ModularShips.Core.Models.Enums;

namespace ModularShips.Core.Models.Interfaces
{
    public interface IDamageable
    {
        Damage ApplyDamage(Damage damage, Direction direction);
    }
}
