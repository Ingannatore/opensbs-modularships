﻿using System;
using ModularShips.Core;
using ModularShips.Core.Entities;
using ModularShips.Core.Messages;
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

            var deltaT = TimeSpan.FromSeconds(1);
            var viper = factory.Create("TEST", library.Get("ship:small:viper"));
            var powerplant = viper.Modules.Get<PowerplantModule>(EntitySubcategory.ModulePowerplant);
            var engine = viper.Modules.Get<EngineModule>(EntitySubcategory.ModuleEngine);
            var shield = viper.Modules.Get<ShieldModule>(EntitySubcategory.ModuleShield);

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine($"--- UPDATE {i} ---");

                switch (i)
                {
                    case 1:
                        engine.HandleMessage(new Message(null, "setPowerLevel", 100));
                        Console.WriteLine("<COMMAND> engine.setPowerLevel(100)");
                        break;
                    case 2:
                        engine.HandleMessage(new Message(null, "setThrottle", 10));
                        Console.WriteLine("<COMMAND> engine.setThrottle(10)");
                        break;
                    case 3:
                        viper.Hull.ApplyDamage(new Damage(DamageType.Kinetic, 40));
                        Console.WriteLine("<DAMAGE> Kinetic:40");
                        break;
                    case 4:
                        shield.HandleMessage(new Message(null, "setPowerLevel", 100));
                        Console.WriteLine("<COMMAND> shield.setPowerLevel(100)");
                        break;
                    case 5:
                        engine.HandleMessage(new Message(null, "setThrottle", 0));
                        Console.WriteLine("<COMMAND> engine.setThrottle(0)");
                        break;
                    case 6:
                        viper.Hull.ApplyDamage(new Damage(DamageType.Kinetic, 40));
                        Console.WriteLine("<DAMAGE> Kinetic:40");
                        break;
                    case 7:
                        powerplant.HandleMessage(new Message(null, "setPowerLevel", 50));
                        Console.WriteLine("<COMMAND> powerplant.setPowerLevel(50)");
                        break;
                }

                viper.Update(deltaT);

                Console.WriteLine(viper.Hull);
                Console.WriteLine(viper.Body);
                Console.WriteLine(powerplant);
                Console.WriteLine(engine);
                Console.WriteLine(shield);
                Console.WriteLine();
            }
        }
    }
}
