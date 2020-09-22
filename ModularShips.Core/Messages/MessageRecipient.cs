﻿namespace ModularShips.Core.Messages
{
    public class MessageRecipient
    {
        private readonly string _raw;

        public string EntityId { get; }
        public string ModuleId { get; }
        public bool IsModule => !string.IsNullOrEmpty(ModuleId);

        public MessageRecipient(string raw)
        {
            _raw = raw;

            var pieces = string.IsNullOrEmpty(_raw) ? new string[0] : _raw.Split('/');
            switch (pieces.Length)
            {
                case 1:
                    EntityId = pieces[0];
                    break;
                case 2:
                    EntityId = pieces[0];
                    ModuleId = pieces[1];
                    break;
                default:
                    EntityId = null;
                    ModuleId = null;
                    break;
            }
        }

        public override string ToString()
        {
            return _raw;
        }
    }
}