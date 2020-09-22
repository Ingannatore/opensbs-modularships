using ModularShips.Core.Templates.Elements;

namespace ModularShips.Core.Templates
{
    public class ShieldTemplate
    {
        public int Power { get; set; }
        public int Capacity { get; set; }
        public int Regeneration { get; set; }
        public DamageElement Resists { get; set; }
    }
}
