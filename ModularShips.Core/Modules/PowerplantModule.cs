using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Messages;
using ModularShips.Core.Models;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public class PowerplantModule : StarshipModule
    {
        public BoundedValue Capacity { get; protected set; }

        public PowerplantModule(Template template) : base(template)
        {
            PowerPriority = 1;
            Capacity = new BoundedValue(template.Powerplant.Capacity);
        }

        public override void OnInstall(Entity owner)
        {
            owner.Powergrid.SetPowerplant(this);
        }

        public override void OnUninstall(Entity owner)
        {
            owner.Powergrid.SetPowerplant(null);
        }

        public override void HandleMessage(Message message) { }

        public override void Update(TimeSpan deltaT, Entity owner)
        {
            Capacity += (int) Math.Round(Template.Powerplant.Power * deltaT.TotalSeconds);
        }

        public bool TryConsumeEnergy(int value)
        {
            if (Capacity.Current < value)
            {
                return false;
            }

            Capacity -= value;
            return true;
        }

        public override string ToString()
        {
            return $"{Capacity} J ({Template.Powerplant.Power} W)";
        }
    }
}
