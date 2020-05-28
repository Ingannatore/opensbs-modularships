using ModularShips.Data;

namespace ModularShips.Models
{
    public class Damage : IndexedValues<DamageType, int>
    {
        private Damage(int kinetic, int thermal, int em)
        {
            Values.Add(DamageType.Kinetic, kinetic);
            Values.Add(DamageType.Thermal, thermal);
            Values.Add(DamageType.Electromagnetic, em);
        }

        public static Damage Create(int kinetic, int thermal, int em)
        {
            return new Damage(kinetic, thermal, em);
        }
    }
}
