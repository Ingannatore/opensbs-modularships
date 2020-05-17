using System;
using System.Collections.Generic;
using ModularShips.Models;
using ModularShips.Modules;

namespace ModularShips.Starships
{
    public class HullSection
    {
        public Guid Id { get; }
        public ICollection<Orientation> Orientations { get; }
        private ICollection<Module> _modules;

        public static HullSection AllAround => new HullSection(Orientation.AllAround);
        public static HullSection HalfFront => new HullSection(Orientation.HalfFront);
        public static HullSection HalfRear => new HullSection(Orientation.HalfRear);

        protected HullSection(params Orientation[] orientations)
        {
            Id = Guid.NewGuid();
            Orientations = new List<Orientation>(orientations);
            _modules = new List<Module>();
        }

        public void AssignModule(Module module)
        {
            _modules.Add(module);
        }
    }
}
