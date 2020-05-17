namespace ModularShips.Models
{
    public class HitPoints : BoundedValue<int>
    {
        public HitPoints(int max) : base(max) { }
    }
}
