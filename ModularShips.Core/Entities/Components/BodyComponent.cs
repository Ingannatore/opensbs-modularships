using System;
using System.Numerics;

namespace ModularShips.Core.Entities.Components
{
    public class BodyComponent
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

        public void Update(TimeSpan deltaT)
        {
            RotateBody(deltaT);
            MoveBody(deltaT);
        }

        public override string ToString()
        {
            return $"[BODY] Position={Position}, Direction={Direction}, LinearSpeed={LinearSpeed}, AngularSpeed={AngularSpeed}";
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
