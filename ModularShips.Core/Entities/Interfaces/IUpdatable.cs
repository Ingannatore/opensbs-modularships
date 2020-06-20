using System;

namespace ModularShips.Core.Entities.Interfaces
{
    public interface IUpdatable
    {
        void Update(TimeSpan deltaT, Entity owner);
    }
}
