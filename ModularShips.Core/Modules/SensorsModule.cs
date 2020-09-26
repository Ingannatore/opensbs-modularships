using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Messages;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public class SensorsModule : PoweredModule
    {
        public SensorsModule(Template template) : base(template)
        {
            Priority = 4;
            NominalPower = template.Sensors.Power;
        }

        public override void OnInstall(Entity owner) { }
        public override void OnUninstall(Entity owner) { }
        public override void HandleMessage(Message message) { }
        public override void Update(TimeSpan deltaT, Entity owner) { }
    }
}
