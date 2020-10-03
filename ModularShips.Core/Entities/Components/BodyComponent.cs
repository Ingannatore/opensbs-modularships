using System;
using System.Collections.Generic;
using System.Numerics;
using ModularShips.Core.Models.Enums;
using ModularShips.Core.Utils;

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

        public IEnumerable<Direction> GetDirections(Vector3? point)
        {
            if (point.HasValue)
            {
                return new[] {Angles.ToDirection(Vectors.AngleBetween(point.Value - Position, Direction))};
            }

            return (Direction[]) Enum.GetValues(typeof(Direction));
        }

        public override string ToString()
        {
            return $"[BODY] Pos={Position}, Dir={Direction}, Speed={LinearSpeed}, AngularSpeed={AngularSpeed}";
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
