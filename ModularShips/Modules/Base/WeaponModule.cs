using ModularShips.Data;

namespace ModularShips.Modules.Base
{
    public abstract class WeaponModule : Module
    {
        public int EnergyPerShot { get; protected set; }
        public int TimePerShot { get; protected set; }
        public Range Range { get; protected set; }
        public DamageProfile DamagePerShot { get; protected set; }
        public int AmmunitionPerShot { get; protected set; }
        public AmmunitionType? AmmunitionType { get; protected set; }
        public Orientation Orientation { get; }

        protected WeaponModule(string name, Size size, Orientation orientation) : base(
            name, size, ModuleCategory.Weapon
        )
        {
            Orientation = orientation;
        }

        protected WeaponModule SetShotProfile(int energyPerShot, int timePerShot)
        {
            EnergyPerShot = energyPerShot;
            TimePerShot = timePerShot;
            return this;
        }

        protected WeaponModule SetDamageProfile(Range range, DamageProfile damagePerShot)
        {
            Range = range;
            DamagePerShot = damagePerShot;
            return this;
        }

        protected WeaponModule SetAmmunitionProfile(int ammunitionPerShot, AmmunitionType type)
        {
            AmmunitionPerShot = ammunitionPerShot;
            AmmunitionType = type;
            return this;
        }
    }
}
