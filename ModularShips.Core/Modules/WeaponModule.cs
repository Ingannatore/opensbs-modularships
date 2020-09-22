using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Messages;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public class WeaponModule : StarshipModule
    {
        public WeaponModule(Template template) : base(template)
        {
            PowerPriority = 5;
        }

        public override void OnInstall(Entity owner) { }
        public override void OnUninstall(Entity owner) { }
        public override void HandleMessage(Message message) { }
        public override void Update(TimeSpan deltaT, Entity owner) { }
    }
}
