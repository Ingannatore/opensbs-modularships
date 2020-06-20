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

            var deltaT = TimeSpan.FromSeconds(0.25);

            var powerplant = viper.Modules.Get<PowerplantModule>(EntitySubcategory.ModulePowerplant);
            powerplant.TurnOn(viper);

            viper.Update(deltaT);

            var engines = viper.Modules.Get<EngineModule>(EntitySubcategory.ModuleEngine);
            engines.TurnOn(viper);
            engines.Rudder = 1;
            engines.Throttle = 50;

            viper.Update(deltaT);

            for (var i = 0; i < 80; i++)
            {
                switch (i)
                {
                    case 10:
                        viper.ApplyDamage(new Damage(DamageType.Kinetic, 50));
                        break;
                    case 20:
                        viper.Modules.Get<ShieldModule>(EntitySubcategory.ModuleShield).TurnOn(viper);
                        engines.Rudder = 0;
                        break;
                    case 40:
                        viper.ApplyDamage(new Damage(DamageType.Kinetic, 50));
                        engines.Rudder = -1;
                        break;
                    case 60:
                        engines.TurnOff();
                        break;
                }

                viper.Update(deltaT);
                Console.WriteLine($"UPDATE {i}");
                Console.WriteLine(viper.Modules.GetShieldModule());
                Console.WriteLine(viper.Hull);
                Console.WriteLine();
                // Console.WriteLine(viper.Powergrid);
                // Console.WriteLine(
                //     FormattableString.Invariant(
                //         $"<text x=\"{viper.Body.Position.X + 8}\" y=\"{viper.Body.Position.Z * -1 + 8}\" fill=\"#999999\" font-size=\"16\">{viper.Body.LinearSpeed} ({i})</text>"
                //     )
                // );
                // Console.WriteLine(
                //     FormattableString.Invariant(
                //         $"<circle cx=\"{viper.Body.Position.X}\" cy=\"{viper.Body.Position.Z * -1}\" r=\"4\" fill=\"red\"/>"
                //     )
                // );
            }
        }
    }
}
