using System.Collections.Generic;
using ModularShips.Data;
using ModularShips.Entities;

namespace ModularShips.Templates
{
    public abstract class ModuleTemplate : ItemTemplate
    {
        protected ModuleTemplate()
        {
            Category = EntityCategory.Module;

            ActivationCost = 0;
            ActivationTime = 0;
            SingleActivation = false;

            Storage = new Dictionary<StorageType, int>();
        }

        public int ActivationCost { get; protected set; }
        public int ActivationTime { get; protected set; }
        public bool SingleActivation { get; protected set; }
        public IDictionary<StorageType, int> Storage { get; }
    }
}
