using ModularShips.Core.Models;

namespace ModularShips.Core.Templates.Elements
{
    public class DefenseElement
    {
        public DefenseLayer Layer { get; set; }
        public DamageResistsElement Resists { get; set; }
        public DefenseValuesElement Values { get; set; }
        public int Regeneration { get; set; }
    }
}
