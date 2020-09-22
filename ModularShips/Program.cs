using System;
using ModularShips.Core;
using ModularShips.Core.Entities;
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
            var shield = viper.Modules.Get<ShieldModule>(EntitySubcategory.ModuleShield);

            Console.WriteLine(shield);
            Console.WriteLine(viper.Hull);
            Console.WriteLine();

            viper.Hull.ApplyDamage(new Damage(DamageType.Kinetic, 10));

            Console.WriteLine(shield);
            Console.WriteLine(viper.Hull);
            Console.WriteLine();
        }
    }
}
