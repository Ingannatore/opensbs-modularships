using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Messages;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public class SensorsModule : StarshipModule
    {
        public SensorsModule(Template template) : base(template)
        {
            PowerPriority = 4;
        }

        public override void OnInstall(Entity owner) { }
        public override void OnUninstall(Entity owner) { }
        public override void HandleMessage(Message message) { }
        public override void Update(TimeSpan deltaT, Entity owner) { }
    }
}
