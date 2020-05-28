using System;
using System.Collections.Generic;

namespace ModularShips.Templates
{
    public static class TemplateLibrary
    {
        private static readonly IDictionary<Type, ItemTemplate> Templates = new Dictionary<Type, ItemTemplate>();

        public static T Get<T>() where T : ItemTemplate, new()
        {
            var templateType = typeof(T);
            if (!Templates.ContainsKey(templateType))
            {
                Templates[templateType] = new T();
            }

            return (T) Templates[templateType];
        }
    }
}
