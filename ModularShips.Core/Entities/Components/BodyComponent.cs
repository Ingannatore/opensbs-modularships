using System;
using System.Numerics;
using ModularShips.Core.Entities.Interfaces;

namespace ModularShips.Core.Entities.Components
{
    public class BodyComponent : IUpdatable
    {
        public int Mass { get; }
        public Vector3 Position { get; private set; }
        public Vector3 Direction { get; private set; }
        public double LinearSpeed { get; set; }
        public double AngularSpeed { get; set; }

        public BodyComponent(int mass, Vector3 position, Vector3 direction)
        {
            Mass = mass;
            Position = position;
            Direction = direction;
        }

        public void Update(TimeSpan deltaT, Entity owner)
        {
            RotateBody(deltaT);
            MoveBody(deltaT);
        }

        private void RotateBody(TimeSpan deltaT)
        {
            var deltaYaw = AngularSpeed * deltaT.TotalSeconds;
            Direction = Vectors.ChangeDirection(Direction, deltaYaw, 0, 0);
        }

        private void MoveBody(TimeSpan deltaT)
        {
            var deltaMovement = LinearSpeed * deltaT.TotalSeconds;
            Position = Vectors.Move(Position, Direction, deltaMovement);
        }
    }
}
