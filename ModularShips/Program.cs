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
            var reactor = viper.GetModule<ReactorModule>(EntitySubcategory.ModuleReactor);
            reactor.TurnOn();

            var shields = viper.GetModule<ShieldModule>(EntitySubcategory.ModuleShield);
            shields.TurnOn();

            var engines = viper.GetModule<EngineModule>(EntitySubcategory.ModuleEngine);
            engines.Rudder = 1;
            engines.Throttle = 50;
            engines.TurnOn();

            var weapons = viper.GetModules<WeaponModule>(EntitySubcategory.ModuleWeapon).ToList();

            var deltaT = TimeSpan.FromSeconds(0.25);
            for (var i = 0; i < 80; i++)
            {
                Console.WriteLine($"UPDATE TIME {deltaT.TotalSeconds * (i + 1)}");

                switch (i)
                {
                    case 4:
                        weapons.First().TurnOn();
                        Console.WriteLine($"EVENT: Weapon ON");
                        break;
                    case 20:
                        engines.Rudder = 0;
                        Console.WriteLine($"EVENT: Rudder 0");
                        break;
                    case 40:
                        engines.Rudder = -1;
                        Console.WriteLine($"EVENT: Rudder -1");
                        break;
                    case 60:
                        engines.Throttle = 0;
                        engines.TurnOff();
                        Console.WriteLine($"EVENT: Throttle to 0 and Engines off");
                        break;
                    case 70:
                        shields.TurnOff();
                        Console.WriteLine($"EVENT: Shields OFF");
                        break;
                }

                viper.Update(deltaT);
                Console.WriteLine("SHIP STATUS");
                Console.WriteLine($"  Capacitor: {viper.Capacitor}");
                Console.WriteLine($"  Reactor: {reactor.IsOn}");
                Console.WriteLine($"  Engines: {engines.IsOn}");
                Console.WriteLine($"  Shields: {shields.IsOn}");
                Console.WriteLine($"  Weap #1: {weapons.First().IsOn}");
                Console.WriteLine();
                // Console.WriteLine($"[{i}] P: {viper.Position}, D: {viper.Direction} (Speed: {engines.Speed})");
                // Console.WriteLine(
                //     FormattableString.Invariant(
                //         $"<text x=\"{viper.Position.X + 8}\" y=\"{viper.Position.Z * -1 + 8}\" fill=\"#999999\" font-size=\"16\">{engines.Speed}</text>"
                //     )
                // );
                // Console.WriteLine(
                //     FormattableString.Invariant(
                //         $"<circle cx=\"{viper.Position.X}\" cy=\"{viper.Position.Z * -1}\" r=\"4\" fill=\"red\"/>"
                //     )
                // );
            }
        }
    }
}
