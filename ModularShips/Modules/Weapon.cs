using ModularShips.Modules.Base;

namespace ModularShips.Modules
{
    public abstract class Weapon : Module
    {
        public int EnergyPerShot { get; protected set; }
        public int TimePerShot { get; protected set; }
        public Range Range { get; protected set; }
        public int DamagePerShot { get; protected set; }
        public int AmmunitionPerShot { get; protected set; }
        public AmmunitionType? AmmunitionType { get; protected set; }
        public Orientation Orientation { get; }

        protected Weapon(string name, Orientation orientation) : base(name, ModuleCategory.Weapon)
        {
            Orientation = orientation;
        }

        protected Weapon SetShotProfile(int energyPerShot, int timePerShot)
        {
            EnergyPerShot = energyPerShot;
            TimePerShot = timePerShot;
            return this;
        }

        protected Weapon SetDamageProfile(Range range, int damagePerShot)
        {
            Range = range;
            DamagePerShot = damagePerShot;
            return this;
        }

        protected Weapon SetAmmunitionProfile(int ammunitionPerShot, AmmunitionType type)
        {
            AmmunitionPerShot = ammunitionPerShot;
            AmmunitionType = type;
            return this;
        }
    }
}
