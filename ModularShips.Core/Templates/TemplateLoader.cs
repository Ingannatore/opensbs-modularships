using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ModularShips.Core.Templates
{
    public static class TemplateLoader
    {
        public static IEnumerable<Template> Load(string path)
        {
            var templates = Directory.GetFiles(path, "*.json", SearchOption.AllDirectories);

            var results = new List<Template>();
            foreach (var templatePath in templates)
            {
                var jsonString = File.ReadAllText(templatePath);
                results.Add(JsonConvert.DeserializeObject<Template>(jsonString));
            }

            return results;
        }
    }
}
