using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Models;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public abstract class ActiveModule : Module
    {
        public bool IsOn { get; private set; }
        private readonly bool _needsEnergy;
        private readonly int _energyPerSecond;
        private TimeSpan _currentActivationTimer;

        protected ActiveModule(Template template) : base(template)
        {
            _needsEnergy = template.Activation.Energy < 0;
            _energyPerSecond = template.Activation.EnergyPerSecond;
            _currentActivationTimer = TimeSpan.Zero;
        }

        public override void Update(TimeSpan deltaT, Entity owner)
        {
            if (!IsOn)
            {
                return;
            }

            _currentActivationTimer = _currentActivationTimer.Subtract(deltaT);
            if (_currentActivationTimer.TotalSeconds <= 0)
            {
                switch (Template.Activation.Mode)
                {
                    case ActivationMode.Single:
                        TurnOff();
                        return;
                    case ActivationMode.Multi:
                        TurnOn();
                        break;
                }
            }

            var energy = (int) Math.Round(_energyPerSecond * deltaT.TotalSeconds);
            if (!_needsEnergy)
            {
                owner.Capacitor.AddEnergy(energy);
                return;
            }

            if (!owner.Capacitor.ConsumeEnergy(energy))
            {
                TurnOff();
            }
        }

        public void TurnOn()
        {
            IsOn = true;
            _currentActivationTimer = TimeSpan.FromSeconds(Template.Activation.Time);
        }

        public void TurnOff()
        {
            IsOn = false;
            _currentActivationTimer = TimeSpan.Zero;
        }
    }
}
