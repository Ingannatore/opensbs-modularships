using ModularShips.Data;

namespace ModularShips.Models
{
    public class DefenseCapacity : IndexedValues<StarshipSection, int>
    {
        private DefenseCapacity(int value)
        {
            Values[StarshipSection.Middle] = value;
        }

        private DefenseCapacity(int frontValue, int rearValue)
        {
            Values[StarshipSection.Front] = frontValue;
            Values[StarshipSection.Rear] = rearValue;
        }

        private DefenseCapacity(int frontValue, int middleValue, int rearValue)
        {
            Values[StarshipSection.Front] = frontValue;
            Values[StarshipSection.Middle] = middleValue;
            Values[StarshipSection.Rear] = rearValue;
        }

        public static DefenseCapacity Create(int value)
        {
            return new DefenseCapacity(value);
        }

        public static DefenseCapacity Create(int frontValue, int rearValue)
        {
            return new DefenseCapacity(frontValue, rearValue);
        }

        public static DefenseCapacity Create(int frontValue, int middleValue, int rearValue)
        {
            return new DefenseCapacity(frontValue, middleValue, rearValue);
        }
    }
}
