using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public class ShieldModule : ActiveModule
    {
        public ShieldModule(Template template) : base(template)
        {
            Priority = 4;
        }
    }
}
