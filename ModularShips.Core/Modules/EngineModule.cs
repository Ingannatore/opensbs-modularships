﻿using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public class EngineModule : ActiveModule
    {
        public int Throttle { get; set; }
        public int Rudder { get; set; }
        private int RudderDirection => Math.Sign(Rudder);
        private double TargetSpeed => Template.Engine.MaximumSpeed * (Throttle / 100.0);

        public EngineModule(Template template) : base(template)
        {
            Priority = 3;
        }

        public override void Update(TimeSpan deltaT, Entity owner)
        {
            // base.Update(deltaT, owner);
            if (!IsOn)
            {
                Rudder = 0;
                Throttle = 0;
            }

            RotateOwner(deltaT, owner);
            MoveOwer(deltaT, owner);
        }

        private void RotateOwner(TimeSpan deltaT, Entity owner)
        {
            if (RudderDirection == 0)
            {
                owner.Body.AngularSpeed = 0;
            }
            else
            {
                owner.Body.AngularSpeed = RudderDirection * Template.Engine.RotationSpeed * (Math.PI / 180);
            }
        }

        private void MoveOwer(TimeSpan deltaT, Entity owner)
        {
            var linearSpeedDirection = Math.Sign(TargetSpeed - owner.Body.LinearSpeed);
            if (linearSpeedDirection < 0)
            {
                var deltaSpeed = Template.Engine.Deceleration * deltaT.TotalSeconds;
                owner.Body.LinearSpeed = Math.Max(owner.Body.LinearSpeed - deltaSpeed, -Template.Engine.MaximumSpeed);
            }
            else if (linearSpeedDirection > 0)
            {
                var deltaSpeed = Template.Engine.Acceleration * deltaT.TotalSeconds;
                owner.Body.LinearSpeed = Math.Min(owner.Body.LinearSpeed + deltaSpeed, Template.Engine.MaximumSpeed);
            }
        }
    }
}
