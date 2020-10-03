using System;
using System.Collections.Generic;
using System.Numerics;
using ModularShips.Core.Entities;
using ModularShips.Core.Models;
using ModularShips.Core.Models.Enums;
using ModularShips.Core.Modules;
using ModularShips.Core.Templates;
using Newtonsoft.Json.Linq;

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
            var powerplant = viper.Hull.GetModule<PowerplantModule>(EntitySubcategory.ModulePowerplant);
            var engine = viper.Hull.GetModule<EngineModule>(EntitySubcategory.ModuleEngine);
            var shield = viper.Hull.GetModule<ShieldModule>(EntitySubcategory.ModuleShield);

            var messages = new Dictionary<int, Message>
            {
                {
                    1,
                    new Message(
                        viper.Id.ToString(), engine.Id.ToString(),
                        "setPowerLevel",
                        JToken.FromObject(100)
                    )
                },
                {
                    2,
                    new Message(
                        viper.Id.ToString(), engine.Id.ToString(),
                        "setThrottle",
                        JToken.FromObject(10)
                    )
                },
                {
                    3,
                    new Message(
                        viper.Id.ToString(), null,
                        "applyDamage",
                        JToken.FromObject(new Damage(DamageType.Kinetic, 40, new Vector3(0, 0, 50)))
                    )
                },
                {
                    4,
                    new Message(
                        viper.Id.ToString(), shield.Id.ToString(),
                        "setPowerLevel",
                        JToken.FromObject(100)
                    )
                },
                {
                    5,
                    new Message(
                        viper.Id.ToString(), engine.Id.ToString(),
                        "setThrottle",
                        JToken.FromObject(0)
                    )
                },
                {
                    6,
                    new Message(
                        viper.Id.ToString(), powerplant.Id.ToString(),
                        "setPowerLevel",
                        JToken.FromObject(50)
                    )
                },
                {
                    7,
                    new Message(
                        viper.Id.ToString(), null,
                        "applyDamage",
                        JToken.FromObject(new Damage(DamageType.Kinetic, 40, new Vector3(0, 0, 50)))
                    )
                },
                {
                    8,
                    new Message(
                        viper.Id.ToString(), powerplant.Id.ToString(),
                        "setPowerLevel",
                        JToken.FromObject(75)
                    )
                },
                {
                    9,
                    new Message(
                        viper.Id.ToString(), null,
                        "applyDamage",
                        JToken.FromObject(new Damage(DamageType.Thermal, 100))
                    )
                }
            };

            var deltaT = TimeSpan.FromSeconds(1);
            for (var i = 0; i < 11; i++)
            {
                Console.WriteLine($"--- UPDATE {i} ---");
                if (messages.ContainsKey(i))
                {
                    Console.WriteLine(messages[i]);
                    viper.HandleMessage(messages[i]);
                }

                viper.Update(deltaT);

                Console.WriteLine(viper.Body);
                Console.WriteLine(viper.Hull);
                Console.WriteLine(viper.Powergrid);
                Console.WriteLine(powerplant);
                Console.WriteLine(engine);
                Console.WriteLine(shield);
                Console.WriteLine();
            }
        }
    }
}
