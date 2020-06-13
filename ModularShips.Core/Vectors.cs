﻿using System.Numerics;

namespace ModularShips.Core
{
    public static class Vectors
    {
        public static Vector3 ChangeDirection(Vector3 value, double yaw, double pitch, double roll)
        {
            var rotationQuaternion = Quaternion.CreateFromYawPitchRoll((float) yaw, (float) pitch, (float) roll);
            return Vector3.Normalize(Vector3.Transform(value, rotationQuaternion));
        }

        public static Vector3 Move(Vector3 position, Vector3 direction, double value)
        {
            return position + direction * (float) value;
        }
    }
}