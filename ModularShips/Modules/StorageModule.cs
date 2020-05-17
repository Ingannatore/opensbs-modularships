﻿using ModularShips.Data;

namespace ModularShips.Modules
{
    public abstract class StorageModule : Module
    {
        protected StorageModule(string name, Size size, MatterState type, int capacity) : base(
            name, size, ModuleCategory.Storage
        )
        {
            AddStorage(type, capacity);
        }
    }
}