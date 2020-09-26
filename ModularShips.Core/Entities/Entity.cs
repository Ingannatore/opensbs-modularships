using System;
using System.Numerics;
using ModularShips.Core.Entities.Components;
using ModularShips.Core.Models;
using ModularShips.Core.Models.Enums;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Entities
{
    public class Entity : Thing
    {
        private const string ApplyDamageCommand = "applyDamage";

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

        public void HandleMessage(Message message)
        {
            if (message.RecipientType == RecipientType.Module)
            {
                Modules.HandleMessage(message);
                return;
            }

            switch (message.Command)
            {
                case ApplyDamageCommand:
                    ApplyDamage(message.Content.ToObject<Damage>());
                    break;
            }
        }

        public void Update(TimeSpan deltaT)
        {
            Powergrid.Reset();
            Modules.Update(deltaT, this);
            Powergrid.Update(deltaT);
            Body.Update(deltaT);
        }

        private void ApplyDamage(Damage damage)
        {
            if (damage.IsDirectional)
            {
                Hull.ApplyDamage(damage, Body.GetDirection(damage.From.Value));
            }
            else
            {
                Hull.ApplyDamage(damage);
            }

        }
    }
}
