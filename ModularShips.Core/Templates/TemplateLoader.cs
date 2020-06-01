using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ModularShips.Core.Templates
{
    public static class TemplateLoader
    {
        public static IEnumerable<Template> Load(string path)
        {
            var options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};
            options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            var templates = Directory.GetFiles(path, "*.json", SearchOption.AllDirectories);

            var result = new List<Template>();
            foreach (var templatePath in templates)
            {
                var jsonString = File.ReadAllText(templatePath);
                result.Add(JsonSerializer.Deserialize<Template>(jsonString, options));
            }

            return result;
        }
    }
}
