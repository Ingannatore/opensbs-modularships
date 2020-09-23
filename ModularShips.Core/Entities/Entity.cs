﻿using System;
using System.Numerics;
using ModularShips.Core.Entities.Components;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Entities
{
    public class Entity : Thing
    {
        public string Name { get; }
        public BodyComponent Body { get; }
        public HullComponent Hull { get; }
        public PowergridComponent Powergrid { get; }
        public ModuleCollection Modules { get; }

        public Entity(string name, Template template) : base(template)
        {
            Name = name;
            Body = new BodyComponent(template.Mass, Vector3.Zero, Vector3.UnitX);
            Hull = new HullComponent(template.Hitpoints);
            Powergrid = new PowergridComponent();
            Modules = new ModuleCollection();
        }

        public void Update(TimeSpan deltaT)
        {
            Modules.Update(deltaT, this);
            Body.Update(deltaT);
        }
    }
}
