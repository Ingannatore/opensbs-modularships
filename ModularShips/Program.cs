using System;
using ModularShips.Core.Templates;

namespace ModularShips
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            const string folder = "./data/templates";
            var library = new TemplateLibrary(TemplateLoader.Load(folder));

            Console.WriteLine(library.Get("ship:small:viper").Name);
        }
    }
}
