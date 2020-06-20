using System;

namespace ModularShips.Core.Models
{
    public class BoundedValue
    {
        public int Max { get; }
        public int Min { get; }
        public int Current { get; private set; }
        public bool IsMax => Current == Max;

        public BoundedValue(int max, int min = 0)
        {
            Max = Current = max;
            Min = min;
        }

        public static BoundedValue operator +(BoundedValue a, int b)
        {
            a.Current = Math.Max(a.Min, Math.Min(a.Max, a.Current + b));
            return a;
        }

        public static BoundedValue operator -(BoundedValue a, int b)
        {
            a.Current = Math.Max(a.Min, Math.Min(a.Max, a.Current - b));
            return a;
        }

        public override string ToString()
        {
            return $"{Current}/{Max}";
        }
    }
}
