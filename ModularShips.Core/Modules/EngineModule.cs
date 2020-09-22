using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Messages;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public class EngineModule : StarshipModule
    {
        public int Throttle { get; set; }
        public int Rudder { get; set; }
        public double LinearSpeed { get; set; }
        public double AngularSpeed { get; set; }
        public int RudderDirection => Math.Sign(Rudder);
        public double TargetSpeed => Template.Engine.MaximumSpeed * (Throttle / 100.0);

        public EngineModule(Template template) : base(template)
        {
            PowerPriority = 2;
        }

        public override void OnInstall(Entity owner) { }
        public override void OnUninstall(Entity owner) { }
        public override void HandleMessage(Message message) { }

        public override void Update(TimeSpan deltaT, Entity owner)
        {
            AngularSpeed = CalculateAngularSpeed(deltaT);
            LinearSpeed = CalculateLinearSpeed(deltaT);

            owner.Body.AngularSpeed = AngularSpeed;
            owner.Body.LinearSpeed = LinearSpeed;
        }

        public override string ToString()
        {
            return FormattableString.Invariant($"T{Throttle}, R{Rudder}");
        }

        private double CalculateAngularSpeed(TimeSpan deltaT)
        {
            if (RudderDirection == 0)
            {
                return 0;
            }

            return RudderDirection * Template.Engine.RotationSpeed * deltaT.TotalSeconds * (Math.PI / 180);
        }

        private double CalculateLinearSpeed(TimeSpan deltaT)
        {
            var linearSpeedDirection = Math.Sign(TargetSpeed - LinearSpeed);
            if (linearSpeedDirection < 0)
            {
                var deltaSpeed = Template.Engine.Deceleration * deltaT.TotalSeconds;
                return Math.Max(LinearSpeed - deltaSpeed, -Template.Engine.MaximumSpeed);
            }

            if (linearSpeedDirection > 0)
            {
                var deltaSpeed = Template.Engine.Acceleration * deltaT.TotalSeconds;
                return Math.Min(LinearSpeed + deltaSpeed, Template.Engine.MaximumSpeed);
            }

            return LinearSpeed;
        }
    }
}
