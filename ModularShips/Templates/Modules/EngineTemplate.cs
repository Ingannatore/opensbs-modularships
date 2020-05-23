using ModularShips.Entities;

namespace ModularShips.Templates.Modules
{
    public abstract class EngineTemplate : ModuleTemplate
    {
        protected EngineTemplate()
        {
            Subcategory = EntitySubcategory.ModuleEngine;
        }

        public int Acceleration { get; protected set; }
        public int MaximumSpeed { get; protected set; }
        public int RotationSpeed { get; protected set; }
    }
}
