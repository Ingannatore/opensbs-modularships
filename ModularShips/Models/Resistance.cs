using ModularShips.Data;

namespace ModularShips.Models
{
    public class Resistance : IndexedValues<DamageType, float>
    {
        public static Resistance Create(float kinetic, float thermal, float em)
        {
            return new Resistance(kinetic, thermal, em);
        }

        private Resistance(float kinetic, float thermal, float em)
        {
            Values.Add(DamageType.Kinetic, kinetic);
            Values.Add(DamageType.Thermal, thermal);
            Values.Add(DamageType.Electromagnetic, em);
        }
    }
}
