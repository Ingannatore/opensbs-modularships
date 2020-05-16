using ModularShips.Data;

namespace ModularShips.Ammunitions.Base
{
    public class ProjectileAmmunition : Ammunition
    {
        public ProjectileAmmunition(string name, Size size) : base(
            name, size, AmmunitionType.Projectile
        ) { }
    }
}
