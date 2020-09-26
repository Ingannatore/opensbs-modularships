using ModularShips.Core.Models;

namespace ModularShips.Core.Entities.Interfaces
{
    public interface IDamageable
    {
        Damage ApplyDamage(Damage damage, Direction direction);
    }
}
