using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Models;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public abstract class PoweredModule : StarshipModule
    {
        private const string SetPowerLevelCommand = "setPowerLevel";

        public int NominalPower { get; protected set; }
        public BoundedValue PowerLevel { get; protected set; }
        public int CurrentPower => (int) Math.Round(NominalPower * PowerFactor);
        public bool IsDisabled => PowerLevel == 0;
        protected double PowerFactor => PowerLevel.Current / 100.0;

        protected PoweredModule(Template template) : base(template)
        {
            PowerLevel = new BoundedValue(200, 0, 0);
        }

        public override void HandleMessage(Message message)
        {
            if (message.Command == SetPowerLevelCommand)
            {
                PowerLevel = new BoundedValue(200, 0, message.Content.ToObject<int>());
            }
        }

        public override void Update(TimeSpan deltaT, Entity owner)
        {
            if (IsDisabled)
            {
                return;
            }

            var currentEnergy = (int) Math.Round(CurrentPower * deltaT.TotalSeconds);
            if (!owner.Powergrid.TryConsumeEnergy(currentEnergy))
            {
                PowerLevel = new BoundedValue(200, 0, 0);
            }
        }
    }
}
