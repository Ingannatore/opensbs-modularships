using System;
using ModularShips.Core.Entities;
using ModularShips.Core.Entities.Components;
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
            var entity = new Entity(name, template)
            {
                HullComponent = CreateHull(template),
            };

            foreach (var moduleId in template.Modules)
            {
                entity.Modules.Add(CreateModule(moduleId));
            }

            return entity;
        }

        private HullComponent CreateHull(Template template)
        {
            return template.Structure == null ? null : new HullComponent(template.Structure);
        }

        private Module CreateModule(string moduleId)
        {
            var template = _templateLibrary.Get(moduleId);
            switch (template.Subcategory)
            {
                case EntitySubcategory.ModuleEngine:
                    return new EngineModule(template);
                case EntitySubcategory.ModulePowerplant:
                    return new PowerplantModule(template);
                case EntitySubcategory.ModuleSensors:
                    return new SensorsModule(template);
                case EntitySubcategory.ModuleShield:
                    return new ShieldModule(template);
                case EntitySubcategory.ModuleWeapon:
                    return new WeaponModule(template);
                default:
                    throw new Exception($"Unknown module subcategory: {template.Subcategory}");
            }
        }
    }
}
