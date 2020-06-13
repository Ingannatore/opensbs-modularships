using System;

namespace ModularShips.Core.Entities
{
    public interface IUpdatable
    {
        void Update(TimeSpan deltaT, Entity owner);
    }
}
