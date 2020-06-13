using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public class EngineModule : ActiveModule
    {
        public int Throttle { get; set; }
        public int Rudder { get; set; }
        public double Speed { get; private set; }
        private int RudderDirection => Math.Sign(Rudder);
        private double TargetSpeed => Template.Engine.MaximumSpeed * (Throttle / 100.0);
        private bool MustAccelerate => Math.Sign(TargetSpeed - Speed) > 0;
        private bool MustDecelerate => Math.Sign(TargetSpeed - Speed) < 0;

        public EngineModule(Template template) : base(template)
        {
            Priority = 3;
        }

        public override void Update(TimeSpan deltaT, Entity owner)
        {
            base.Update(deltaT, owner);
            if (IsOn)
            {
                RotateOwner(deltaT, owner);
                MoveOwer(deltaT, owner);
            }
        }

        private void RotateOwner(TimeSpan deltaT, Entity owner)
        {
            if (RudderDirection == 0)
            {
                return;
            }

            var deltaYaw = RudderDirection * (Angles.ToRadians(Template.Engine.RotationSpeed) * deltaT.TotalSeconds);
            owner.SetDirection(Vectors.ChangeDirection(owner.Direction, deltaYaw, 0, 0));
        }

        private void MoveOwer(TimeSpan deltaT, Entity owner)
        {
            if (MustDecelerate)
            {
                var deltaSpeed = Template.Engine.Deceleration * deltaT.TotalSeconds;
                Speed = Math.Max(Speed - deltaSpeed, -Template.Engine.MaximumSpeed);
            }

            if (MustAccelerate)
            {
                var deltaSpeed = Template.Engine.Acceleration * deltaT.TotalSeconds;
                Speed = Math.Min(Speed + deltaSpeed, Template.Engine.MaximumSpeed);
            }

            var deltaMovement = Speed * deltaT.TotalSeconds;
            owner.SetPosition(Vectors.Move(owner.Position, owner.Direction, deltaMovement));
        }
    }
}
