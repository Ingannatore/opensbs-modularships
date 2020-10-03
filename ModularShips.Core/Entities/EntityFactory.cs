using System;
using ModularShips.Core.Models.Enums;
using ModularShips.Core.Modules;
using ModularShips.Core.Templates;

namespace ModularShips.Core.Entities
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
                entity.InstallModule(CreateModule(slot.ModuleId), slot.Location);
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
