using System;
using System.Collections.Generic;

namespace ModularShips.Core.Templates
{
    public class TemplateLibrary
    {
        private readonly IDictionary<string, Template> _templates;

        public TemplateLibrary(IEnumerable<Template> items)
        {
            _templates = new Dictionary<string, Template>();
            foreach (var item in items)
            {
                _templates.Add(item.Id, item);
            }
        }

        public Template Get(string id)
        {
            if (!_templates.ContainsKey(id))
            {
                throw new Exception($"Unknown template: {id}");
            }

            return _templates[id];
        }
    }
}
