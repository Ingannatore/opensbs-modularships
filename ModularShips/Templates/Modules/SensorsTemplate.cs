using ModularShips.Entities;

namespace ModularShips.Templates.Modules
{
    public abstract class SensorsTemplate : ModuleTemplate
    {
        protected SensorsTemplate()
        {
            Subcategory = EntitySubcategory.ModuleSensors;
        }

        public int ScanningStrength { get; protected set; }
        public int TargetingRange { get; protected set; }
        public int MaximumRange { get; protected set; }
    }
}
