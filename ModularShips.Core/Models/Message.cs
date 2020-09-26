using System;
using Newtonsoft.Json.Linq;

namespace ModularShips.Core.Models
{
    public class Message
    {
        public Guid EntityId { get; }
        public Guid ModuleId { get; }
        public string Command { get; }
        public JToken Content { get; }
        public MessageRecipient Recipient { get; }

        public Message(string entityId, string moduleId, string command, JToken content)
        {
            EntityId = string.IsNullOrEmpty(entityId) ? Guid.Empty : new Guid(entityId);
            ModuleId = string.IsNullOrEmpty(moduleId) ? Guid.Empty : new Guid(moduleId);
            Command = command;
            Content = content;
            Recipient = GetRecipientValue();
        }

        public override string ToString()
        {
            return $"<MESSAGE> EntityId={EntityId:N}, ModuleId={ModuleId:N}, Command={Command}";
        }

        private MessageRecipient GetRecipientValue()
        {
            if (ModuleId != Guid.Empty)
            {
                return MessageRecipient.Module;
            }
            if (EntityId != Guid.Empty)
            {
                return MessageRecipient.Entity;
            }

            return MessageRecipient.Global;
        }
    }
}
