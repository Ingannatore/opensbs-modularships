using System;
using System.Numerics;

namespace ModularShips.Core.Entities.Components
{
    public class BodyComponent : IUpdatable
    {
        public Vector3 Position { get; private set; }
        public Vector3 Direction { get; private set; }
        public double LinearSpeed { get; set; }
        public double AngularSpeed { get; set; }

        public BodyComponent(Vector3 position, Vector3 direction)
        {
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
