using ModularShips.Core.Templates.Elements;

namespace ModularShips.Core.Templates
{
    public class SensorsTemplate
    {
        public int Power { get; set; }
        public SensorsStrengthElement Strength { get; set; }
        public RangeElement Range { get; set; }
    }
}
