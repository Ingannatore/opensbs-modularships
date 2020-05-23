using ModularShips.Models;

namespace ModularShips.Templates.Modules
{
    public class DefenseTemplate : ModuleTemplate
    {
        public DefenseCapacity ArmorCapacity { get; protected set; }
        public DefenseCapacity ShieldCapacity { get; protected set; }
        public DamageResistances Resistances { get; protected set; }
        public int RegenerationRate { get; protected set; }
    }
}
