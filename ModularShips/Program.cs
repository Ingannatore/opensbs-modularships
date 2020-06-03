using System;
using System.Linq;
using ModularShips.Core;
using ModularShips.Core.Models;
using ModularShips.Core.Modules;
using ModularShips.Core.Templates;

namespace ModularShips
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            const string folder = "./data/templates";
            var library = new TemplateLibrary(TemplateLoader.Load(folder));
            var factory = new EntityFactory(library);

            var viper = factory.Create("TEST", library.Get("ship:small:viper"));
            Console.WriteLine(viper.Id);
            Console.WriteLine(viper.GetModule<EngineModule>(EntitySubcategory.ModuleEngine));
        }
    }
}
