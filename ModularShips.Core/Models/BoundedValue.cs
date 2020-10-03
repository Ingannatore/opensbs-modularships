using System;

namespace ModularShips.Core.Models
{
    public class BoundedValue
    {
        public int Max { get; }
        public int Min { get; }
        public int Current { get; private set; }
        public bool IsMax => Current == Max;
        public bool IsMin => Current == Min;

        public BoundedValue(int max, int min = 0)
        {
            Max = Current = max;
            Min = min;
        }

        public BoundedValue(int max, int min, int current)
        {
            Max = max;
            Min = min;
            Current = current;
        }

        public int Decrease(int value)
        {
            if (Current >= value)
            {
                Current -= value;
                return 0;
            }

            var delta = value - Current;
            Current = 0;

            return delta;
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

        public static bool operator ==(BoundedValue a, int b)
        {
            return a != null && a.Current == b;
        }

        public static bool operator !=(BoundedValue a, int b)
        {
            return a == null || a.Current != b;
        }

        public static bool operator >(BoundedValue a, int b)
        {
            return a != null && a.Current > b;
        }

        public static bool operator <(BoundedValue a, int b)
        {
            return a != null && a.Current < b;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((BoundedValue) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Max, Min, Current);
        }

        public override string ToString()
        {
            return $"{Current}/{Max}";
        }

        private bool Equals(BoundedValue other)
        {
            return Max == other.Max && Min == other.Min && Current == other.Current;
        }
    }
}
