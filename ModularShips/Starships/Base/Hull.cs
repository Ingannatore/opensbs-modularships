using System;
using System.Collections.Generic;
using ModularShips.Modules.Base;

namespace ModularShips.Starships.Base
{
    public class Hull
    {
        public Dimensions Dimensions { get; }
        public HitPoints HitPoints { get; }
        public IDictionary<Guid, HullSection> Sections { get; }
        public IDictionary<Guid, Module> Modules { get; }

        public static Hull Small => new Hull(Dimensions.Small, 500);
        public static Hull Medium => new Hull(Dimensions.Medium, 2000);
        public static Hull Large => new Hull(Dimensions.Large, 10000);
        public static Hull Capital => new Hull(Dimensions.Capital, 50000);
        public static Hull Station => new Hull(Dimensions.Station, 200000);

        protected Hull(Dimensions dimensions, int hitPoints)
        {
            Dimensions = dimensions;
            HitPoints = new HitPoints(hitPoints);
            Sections = new Dictionary<Guid, HullSection>();
            Modules = new Dictionary<Guid, Module>();
        }

        public void AddSection(HullSection section, IEnumerable<Module> modules)
        {
            Sections.Add(section.Id, section);

            foreach (var module in modules)
            {
                section.AssignModule(module);
                Modules.Add(module.Id, module);
            }
        }
    }
}
