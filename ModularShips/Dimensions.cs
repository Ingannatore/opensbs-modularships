namespace ModularShips
{
    public class Dimensions
    {
        public Size Size { get; }
        public int Length { get; }

        public static Dimensions Tiny => new Dimensions(Size.Tiny, 5);
        public static Dimensions ExtraSmall => new Dimensions(Size.ExtraSmall, 20);
        public static Dimensions Small => new Dimensions(Size.Small, 80);
        public static Dimensions Medium => new Dimensions(Size.Medium, 320);
        public static Dimensions Large => new Dimensions(Size.Large, 720);
        public static Dimensions Capital => new Dimensions(Size.Capital, 1280);
        public static Dimensions Station => new Dimensions(Size.Station, 2000);

        public Dimensions(Size size, int length)
        {
            Size = size;
            Length = length;
        }
    }
}
