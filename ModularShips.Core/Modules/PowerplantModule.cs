using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Models;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public class PowerplantModule : PoweredModule
    {
        public BoundedValue Capacity { get; protected set; }

        public PowerplantModule(Template template) : base(template)
        {
            Priority = 1;
            NominalPower = template.Powerplant.Power;
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

        public override void Update(TimeSpan deltaT, Entity owner)
        {
            if (!IsDisabled)
            {
                Capacity += (int) Math.Round(CurrentPower * Efficacy * deltaT.TotalSeconds);
            }
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
            return $"[POWERPLANT] Capacity={Capacity}, Power={CurrentPower}/{Template.Powerplant.Power}";
        }
    }
}
