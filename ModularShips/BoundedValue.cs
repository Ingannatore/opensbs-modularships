namespace ModularShips
{
    public class BoundedValue<T>
    {
        public T Max { get; }
        public T Current { get; set; }

        public BoundedValue(T max)
        {
            Max = Current = max;
        }

        public BoundedValue(T max, T current)
        {
            Max = max;
            Current = current;
        }

        public override string ToString()
        {
            return $"{Current}/{Max}";
        }
    }
}
