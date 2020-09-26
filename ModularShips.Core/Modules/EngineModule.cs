using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Models;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public class EngineModule : PoweredModule
    {
        private const string SetThrottleCommand = "setThrottle";
        private const string SetRudderCommand = "setRudder";

        public int Throttle { get; set; }
        public int Rudder { get; set; }

        public EngineModule(Template template) : base(template)
        {
            Priority = 2;
            NominalPower = template.Engine.Power;
        }

        public override void OnInstall(Entity owner) { }
        public override void OnUninstall(Entity owner) { }

        public override void HandleMessage(Message message)
        {
            if (IsDisabled)
            {
                base.HandleMessage(message);
                return;
            }

            switch (message.Command)
            {
                case SetThrottleCommand:
                    Throttle = message.Content.ToObject<int>();
                    break;
                case SetRudderCommand:
                    Rudder = message.Content.ToObject<int>();
                    break;
                default:
                    base.HandleMessage(message);
                    break;
            }
        }

        public override void Update(TimeSpan deltaT, Entity owner)
        {
            base.Update(deltaT, owner);
            if (IsDisabled)
            {
                Throttle = 0;
                Rudder = 0;
            }

            owner.Body.AngularSpeed = CalculateAngularSpeed(deltaT);
            owner.Body.LinearSpeed = CalculateLinearSpeed(deltaT, owner);
        }

        public override string ToString()
        {
            return $"[ENGINE] Throttle={Throttle}, Rudder={Rudder}, Power={CurrentPower}/{Template.Engine.Power}";
        }

        private double CalculateAngularSpeed(TimeSpan deltaT)
        {
            var rudderDirection = Math.Sign(Rudder);
            if (rudderDirection == 0)
            {
                return 0;
            }

            return rudderDirection * Template.Engine.RotationSpeed * deltaT.TotalSeconds * (Math.PI / 180);
        }

        private double CalculateLinearSpeed(TimeSpan deltaT, Entity owner)
        {
            var targetSpeed = Template.Engine.MaximumSpeed * (Throttle / 100.0);
            var currentLinearSpeed = owner.Body.LinearSpeed;

            var linearSpeedDirection = Math.Sign(targetSpeed - currentLinearSpeed);
            if (linearSpeedDirection < 0)
            {
                var deceleration = PowerFactor * Template.Engine.Deceleration;
                var deltaSpeed = deceleration * deltaT.TotalSeconds;
                return Math.Max(currentLinearSpeed - deltaSpeed, -Template.Engine.MaximumSpeed);
            }

            if (linearSpeedDirection > 0)
            {
                var acceleration = PowerFactor * Template.Engine.Acceleration;
                var deltaSpeed = acceleration * deltaT.TotalSeconds;
                return Math.Min(currentLinearSpeed + deltaSpeed, Template.Engine.MaximumSpeed);
            }

            return currentLinearSpeed;
        }
    }
}
