using System;
using ModularShips.Modules.Base;

namespace ModularShips.Starships.Base
{
    public abstract class Starship
    {
        public Guid Id { get; }
        public string Name { get; }
        public string FamilyName { get; }
        public int Terminals { get; }
        public StarshipCategory Category { get; }
        public Hull Hull { get; protected set; }

        protected Starship(string name, string familyName, StarshipCategory category, int terminals)
        {
            Id = Guid.NewGuid();
            Name = name;
            FamilyName = familyName;
            Category = category;
            Terminals = terminals;
        }

        public override string ToString()
        {
            return $"{Name}, {FamilyName}-Class {Category:G}";
        }

        protected void InstallHull(Hull hull)
        {
            Hull = hull;
        }

        protected void AddHullSection(HullSection section, params Module[] modules)
        {
            Hull.AddSection(section, modules);
        }
    }
}
