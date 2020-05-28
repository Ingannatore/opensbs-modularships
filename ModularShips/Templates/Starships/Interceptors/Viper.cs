using ModularShips.Data;
using ModularShips.Entities;
using ModularShips.Templates.Hulls.UltraLight;
using ModularShips.Templates.Modules.Engines;
using ModularShips.Templates.Modules.Reactors;
using ModularShips.Templates.Modules.Sensors;
using ModularShips.Templates.Modules.Shields;
using ModularShips.Templates.Modules.Weapons;

namespace ModularShips.Templates.Starships.Interceptors
{
    public class Viper : StarshipTemplate
    {
        public Viper()
        {
            Id = "starship:interceptor:viper";
            Name = "Viper-class Interceptor";
            Description = "The Viper is a fast and agile single-seater, mainly used in combat against other fighters";
            Subcategory = EntitySubcategory.StarshipInterceptor;
            Size = EntitySize.Small;

            HullTemplate = TemplateLibrary.Get<SmallUltraLightHullTemplate>();
            Modules.Add(HullSlotType.Defense, TemplateLibrary.Get<SmallMultiLayerShield>());
            Modules.Add(HullSlotType.Electronics, TemplateLibrary.Get<SmallRadarSensors>());
            Modules.Add(HullSlotType.Engine, TemplateLibrary.Get<SmallIonEngine>());
            Modules.Add(HullSlotType.Reactor, TemplateLibrary.Get<SmallFusionReactor>());
            Modules.Add(HullSlotType.Weapon, TemplateLibrary.Get<SmallMonoEmitterBeam>());
            Modules.Add(HullSlotType.Weapon, TemplateLibrary.Get<SmallMonoEmitterBeam>());
        }
    }
}
