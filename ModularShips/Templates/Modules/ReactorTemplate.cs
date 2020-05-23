using ModularShips.Entities;

namespace ModularShips.Templates.Modules
{
    public abstract class ReactorTemplate : ModuleTemplate
    {
        protected ReactorTemplate()
        {
            Subcategory = EntitySubcategory.ModuleReactor;
        }

        public int EnergyGeneratedPerSecond { get; protected set; }
    }
}
