namespace ModularShips
{
    public class Orientation
    {
        public int Direction { get; }
        public int Extension { get; }

        public static Orientation AllAround => new Orientation(0, 180);
        public static Orientation HalfFront => new Orientation(0, 90);
        public static Orientation HalfRear => new Orientation(180, 90);
        public static Orientation HalfStarboard => new Orientation(90, 90);
        public static Orientation HalfPort => new Orientation(270, 90);
        public static Orientation QuarterFront => new Orientation(0, 45);
        public static Orientation QuarterStarboard => new Orientation(90, 45);
        public static Orientation QuarterRear => new Orientation(180, 45);
        public static Orientation QuarterPort => new Orientation(270, 45);

        protected Orientation(int direction, int extension)
        {
            Direction = direction;
            Extension = extension;
        }
    }
}
