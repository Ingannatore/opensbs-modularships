using System;

namespace ModularShips.Core.Models
{
    public class Capacity
    {
        public int Max { get; }
        public int Current { get; private set; }

        public Capacity(int value)
        {
            Max = Current = value;
        }

        public void Update(int value)
        {
            Current = Math.Max(0, Math.Min(Max, Current + value));
        }

        public override string ToString()
        {
            return $"{Current}/{Max}";
        }
    }
}
