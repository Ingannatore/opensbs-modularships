namespace ModularShips.Core.Models.Interfaces
{
    public interface IDamageable
    {
        Damage ApplyDamage(Damage damage, Direction direction);
    }
}
