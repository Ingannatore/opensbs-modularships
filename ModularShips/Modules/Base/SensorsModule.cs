﻿using ModularShips.Data;

namespace ModularShips.Modules.Base
{
    public abstract class SensorsModule : Module
    {
        public int Strength { get; }
        public Range Range { get; }

        protected SensorsModule(string name, Size size, int strength, Range range) : base(
            name, size, ModuleCategory.Sensors
        )
        {
            Strength = strength;
            Range = range;
        }
    }
}
