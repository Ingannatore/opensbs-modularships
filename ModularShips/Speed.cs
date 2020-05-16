namespace ModularShips
{
    public class Speed : BoundedValue<float>
    {
        public Speed(float max) : base(max, 0) { }
    }
}
