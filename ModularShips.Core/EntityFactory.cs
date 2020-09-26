﻿using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Models;
using ModularShips.Core.Modules;
using ModularShips.Core.Templates;

namespace ModularShips.Core
{
    public class EntityFactory
    {
        private readonly TemplateLibrary _templateLibrary;

        public EntityFactory(TemplateLibrary templateLibrary)
        {
            _templateLibrary = templateLibrary;
        }

        public Entity Create(string name, Template template)
        {
            var entity = new Entity(name, template);
            foreach (var slot in template.Starship.Slots)
            {
                entity.Modules.Add(CreateModule(slot.ModuleId), entity);
            }

            return entity;
        }

        private StarshipModule CreateModule(string moduleId)
        {
            var template = _templateLibrary.Get(moduleId);
            return template.Subcategory switch
            {
                EntitySubcategory.ModuleArmor => new ArmorModule(template),
                EntitySubcategory.ModuleEngine => new EngineModule(template),
                EntitySubcategory.ModulePowerplant => new PowerplantModule(template),
                EntitySubcategory.ModuleSensors => new SensorsModule(template),
                EntitySubcategory.ModuleShield => new ShieldModule(template),
                EntitySubcategory.ModuleWeapon => new WeaponModule(template),
                _ => throw new Exception($"Unknown module subcategory: {template.Subcategory}")
            };
        }
    }
}
