using ModularShips.Data;

namespace ModularShips.Models
{
    public class DamagePacket : IndexedValues<DamageType, int>
    {
        private DamagePacket(int kinetic, int thermal, int em)
        {
            Values.Add(DamageType.Kinetic, kinetic);
            Values.Add(DamageType.Thermal, thermal);
            Values.Add(DamageType.Electromagnetic, em);
        }

        public static DamagePacket Create(int kinetic, int thermal, int em)
        {
            return new DamagePacket(kinetic, thermal, em);
        }
    }
}
