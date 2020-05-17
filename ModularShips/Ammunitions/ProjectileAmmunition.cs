using ModularShips.Data;

namespace ModularShips.Ammunitions
{
    public class ProjectileAmmunition : Ammunition
    {
        public ProjectileAmmunition(string name, Size size) : base(
            name, size, AmmunitionType.Projectile
        ) { }
    }
}
