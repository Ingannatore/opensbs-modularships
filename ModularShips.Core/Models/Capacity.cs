using System;

namespace ModularShips.Core.Models
{
    public class Capacity
    {
        public int Max { get; }
        public int Current { get; protected set; }

        public Capacity(int value)
        {
            Max = Current = value;
        }

        public void Add(int value)
        {
            Current = Math.Min(Max, Current + value);
        }

        public void Subtract(int value)
        {
            Current = Math.Max(0, Current - value);
        }
    }
}
