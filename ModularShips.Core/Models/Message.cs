using System;
using ModularShips.Core.Models.Enums;
using Newtonsoft.Json.Linq;

namespace ModularShips.Core.Models
{
    public class Message
    {
        public Guid EntityId { get; }
        public Guid ModuleId { get; }
        public string Command { get; }
        public JToken Content { get; }
        public RecipientType RecipientType { get; }

        public Message(string entityId, string moduleId, string command, JToken content)
        {
            EntityId = string.IsNullOrEmpty(entityId) ? Guid.Empty : new Guid(entityId);
            ModuleId = string.IsNullOrEmpty(moduleId) ? Guid.Empty : new Guid(moduleId);
            Command = command;
            Content = content;
            RecipientType = GetRecipientValue();
        }

        public override string ToString()
        {
            return $"<MESSAGE> EntityId={EntityId:N}, ModuleId={ModuleId:N}, Command={Command}";
        }

        private RecipientType GetRecipientValue()
        {
            if (ModuleId != Guid.Empty)
            {
                return RecipientType.Module;
            }
            if (EntityId != Guid.Empty)
            {
                return RecipientType.Entity;
            }

            return RecipientType.Global;
        }
    }
}
