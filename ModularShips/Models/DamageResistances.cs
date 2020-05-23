using ModularShips.Data;

namespace ModularShips.Models
{
    public class DamageResistances : IndexedValues<DamageType, float>
    {
        private DamageResistances(float kinetic, float thermal, float em)
        {
            Values.Add(DamageType.Kinetic, kinetic);
            Values.Add(DamageType.Thermal, thermal);
            Values.Add(DamageType.Electromagnetic, em);
        }

        public static DamageResistances Create(float kinetic, float thermal, float em)
        {
            return new DamageResistances(kinetic, thermal, em);
        }
    }
}
