using System;
using System.Text.Json.Serialization;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Entities
{
    public abstract class Thing
    {
        public Guid Id { get; }
        [JsonIgnore] public Template Template { get; }

        public Thing(Template template)
        {
            Id = Guid.NewGuid();
            Template = template;
        }
    }
}
