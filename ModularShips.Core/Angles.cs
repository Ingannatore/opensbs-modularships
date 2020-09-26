using System;
using ModularShips.Core.Models;

namespace ModularShips.Core
{
    public static class Angles
    {
        public static double ToRadians(double value)
        {
            return value * (Math.PI / 180);
        }

        public static double ToDegrees(double value)
        {
            return value * (180 / Math.PI);
        }

        public static Direction ToDirection(double value)
        {
            const double angle45 = Math.PI / 4;
            const double angle135 = 3 * angle45;

            if (Math.Abs(value) <= angle45)
            {
                return Direction.Ahead;
            }
            if (Math.Abs(value) >= angle135)
            {
                return Direction.Astern;
            }

            return value > 0 ? Direction.Port : Direction.Starboard;
        }
    }
}
