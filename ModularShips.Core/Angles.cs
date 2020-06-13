using System;

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
    }
}
