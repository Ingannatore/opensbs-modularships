using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Models;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Modules
{
    public abstract class StarshipModule : Thing, IComparable
    {
        public BoundedValue Hitpoints { get; private set; }
        public int Priority { get; protected set; }
        protected double Efficacy => (double) Hitpoints.Current / Hitpoints.Max;

        protected StarshipModule(Template template) : base(template)
        {
            Hitpoints = new BoundedValue(template.Hitpoints);
        }

        public void ApplyDamage(int amount)
        {
            Hitpoints -= amount;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            if (obj is StarshipModule otherTemperature)
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
