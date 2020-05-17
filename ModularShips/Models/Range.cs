namespace ModularShips.Models
{
    public class Range
    {
        public int Optimal { get; }
        public int Max { get; }

        public static Range PointBlank => new Range(500, 1000);
        public static Range Short => new Range(1000, 2000);
        public static Range Medium => new Range(2500, 5000);

        public static Range Long => new Range(5000, 10000);
        public static Range Extreme => new Range(10000, 20000);

        public Range(int optimal, int max)
        {
            Optimal = optimal;
            Max = max;
        }
    }
}
