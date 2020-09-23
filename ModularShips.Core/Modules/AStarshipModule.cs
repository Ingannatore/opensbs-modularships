using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Messages;
using ModularShips.Core.Models;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public abstract class AStarshipModule : Thing, IComparable
    {
        public BoundedValue Hitpoints { get; }
        public int Priority { get; protected set; }

        protected AStarshipModule(Template template) : base(template)
        {
            Hitpoints = new BoundedValue(template.Hitpoints);
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            if (obj is AStarshipModule otherTemperature)
            {
                return Priority.CompareTo(otherTemperature.Priority);
            }

            throw new ArgumentException("Object is not a StarshipModule");
        }

        public abstract void OnInstall(Entity owner);
        public abstract void OnUninstall(Entity owner);
        public abstract void HandleMessage(Message message);
        public abstract void Update(TimeSpan deltaT, Entity owner);
    }
}
