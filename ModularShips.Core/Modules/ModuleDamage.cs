using System;
using ModularShips.Core.Models.Enums;

namespace ModularShips.Core.Modules
{
    public class ModuleDamage
    {
        public int Amount { get; }
        public HullLocation Location { get; }
        public bool IsZero => Amount == 0;

        public ModuleDamage(int hullDamage, int hullHitpoints, Direction direction)
        {
            Amount = (int) Math.Round(Math.Pow(hullDamage, 2) / hullHitpoints);
            Location = GetLocation(direction);
        }

        private static HullLocation GetLocation(Direction direction)
        {
            return direction switch
            {
                Direction.Ahead => HullLocation.Bow,
                Direction.Astern => HullLocation.Stern,
                _ => HullLocation.Amid
            };
        }
    }
}
